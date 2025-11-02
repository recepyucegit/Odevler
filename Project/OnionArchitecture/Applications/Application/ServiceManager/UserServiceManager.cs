using Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.ServiceManager
{
    public class UserServiceManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserServiceManager(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // ============================================
        // JWT TOKEN ÜRETİMİ
        // ============================================

        /// <summary>
        /// JWT Token üret
        /// </summary>
        private string GenerateToken(IdentityUser user)
        {
            try
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];
                var expiryInMinutes = jwtSettings["ExpiryInMinutes"];

                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new InvalidOperationException("JWT SecretKey appsettings.json'da bulunamadı!");
                }

                if (string.IsNullOrEmpty(issuer))
                {
                    throw new InvalidOperationException("JWT Issuer appsettings.json'da bulunamadı!");
                }

                if (string.IsNullOrEmpty(audience))
                {
                    throw new InvalidOperationException("JWT Audience appsettings.json'da bulunamadı!");
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(int.Parse(expiryInMinutes ?? "60")),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Token oluşturulurken hata: {ex.Message}", ex);
            }
        }

        // ============================================
        // KULLANICI İŞLEMLERİ
        // ============================================

        /// <summary>
        /// Kullanıcı kaydı oluştur
        /// </summary>
        public async Task<(bool Success, string Message, IEnumerable<string> Errors)> RegisterUserAsync(RegisterUserDTO dto)
        {
            try
            {
                // Email kontrolü
                var existingUserByEmail = await _userManager.FindByEmailAsync(dto.Email);
                if (existingUserByEmail != null)
                {
                    return (false, "Bu email adresi zaten kullanılıyor!", new[] { "Email already exists" });
                }

                // Username kontrolü
                var existingUserByUsername = await _userManager.FindByNameAsync(dto.UserName);
                if (existingUserByUsername != null)
                {
                    return (false, "Bu kullanıcı adı zaten kullanılıyor!", new[] { "Username already exists" });
                }

                var user = new IdentityUser
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    EmailConfirmed = false
                };

                var result = await _userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    return (true, "Kullanıcı başarıyla oluşturuldu!", Array.Empty<string>());
                }

                // Hata mesajlarını topla
                var errors = result.Errors.Select(e => e.Description).ToList();
                return (false, "Kullanıcı oluşturulamadı!", errors);
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}", new[] { ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı girişi ve token üretimi
        /// </summary>
        public async Task<(bool Success, string Message, LoginResponseDTO Data)> LoginAsync(LoginRequestDTO dto)
        {
            try
            {
                // Kullanıcıyı bul (email veya username ile)
                var user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail)
                    ?? await _userManager.FindByNameAsync(dto.UserNameOrEmail);

                if (user == null)
                {
                    return (false, "Kullanıcı adı veya şifre hatalı!", null);
                }

                // Şifre kontrolü
                var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

                if (!result.Succeeded)
                {
                    return (false, "Kullanıcı adı veya şifre hatalı!", null);
                }

                // Token üret
                var token = GenerateToken(user);

                var response = new LoginResponseDTO
                {
                    Token = token,
                    UserName = user.UserName,
                    Email = user.Email,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(60)
                };

                return (true, "Giriş başarılı!", response);
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Kullanıcı çıkışı
        /// </summary>
        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// Tüm kullanıcıları getir
        /// </summary>
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = _userManager.Users.ToList();
                return users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    EmailConfirmed = u.EmailConfirmed,
                    PhoneNumberConfirmed = u.PhoneNumberConfirmed
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<UserDTO>();
            }
        }

        /// <summary>
        /// ID ile kullanıcı getir
        /// </summary>
        public async Task<UserDTO?> GetUserByIdAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) return null;

                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Kullanıcı güncelle
        /// </summary>
        public async Task<(bool Success, string Message)> UpdateUserAsync(UpdateUserDTO dto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(dto.Id);
                if (user == null)
                {
                    return (false, "Kullanıcı bulunamadı!");
                }

                // Email değişti mi kontrol et
                if (user.Email != dto.Email)
                {
                    var emailExists = await _userManager.FindByEmailAsync(dto.Email);
                    if (emailExists != null && emailExists.Id != dto.Id)
                    {
                        return (false, "Bu email adresi başka bir kullanıcı tarafından kullanılıyor!");
                    }

                    user.Email = dto.Email;
                    user.EmailConfirmed = false; // Email değiştiyse tekrar onay gereksin
                }

                // Username değişti mi kontrol et
                if (user.UserName != dto.UserName)
                {
                    var usernameExists = await _userManager.FindByNameAsync(dto.UserName);
                    if (usernameExists != null && usernameExists.Id != dto.Id)
                    {
                        return (false, "Bu kullanıcı adı başka bir kullanıcı tarafından kullanılıyor!");
                    }

                    user.UserName = dto.UserName;
                }

                user.PhoneNumber = dto.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return (true, "Kullanıcı başarıyla güncellendi!");
                }

                return (false, "Kullanıcı güncellenemedi!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Şifre değiştir
        /// </summary>
        public async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordDTO dto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId);
                if (user == null)
                {
                    return (false, "Kullanıcı bulunamadı!");
                }

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    dto.CurrentPassword,
                    dto.NewPassword);

                if (result.Succeeded)
                {
                    return (true, "Şifre başarıyla değiştirildi!");
                }

                return (false, "Şifre değiştirilemedi. Mevcut şifrenizi kontrol edin!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Kullanıcı sil
        /// </summary>
        public async Task<(bool Success, string Message)> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return (false, "Kullanıcı bulunamadı!");
                }

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return (true, "Kullanıcı başarıyla silindi!");
                }

                return (false, "Kullanıcı silinemedi!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Email onaylama
        /// </summary>
        public async Task<(bool Success, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return (false, "Kullanıcı bulunamadı!");
                }

                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    return (true, "Email başarıyla onaylandı!");
                }

                return (false, "Email onaylanamadı!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }
    }
}
