using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.DTOs;
using BLL.Services.Abstracts;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly ISupplierServiceManager _supplierService;  
        private readonly ProjectContext _context;  

        // ✅ Constructor - Dependency Injection
        public AuthController(
            IConfiguration configuration,
            ILogger<AuthController> logger,
            ISupplierServiceManager supplierService,  
            ProjectContext context)  
        {
            _configuration = configuration;
            _logger = logger;
            _supplierService = supplierService;  
            _context = context;  
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                //  Veritabanından supplier'ı bul
                var supplier = _supplierService.GetByUsername(loginDto.Username);

                if (supplier == null || supplier.PasswordHash != loginDto.Password)
                {
                    _logger.LogWarning($"Başarısız giriş denemesi: {loginDto.Username}");
                    return Unauthorized(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Kullanıcı adı veya şifre hatalı"
                    });
                }

                //  Yetkileri veritabanından al
                var permissions = _context.SupplierPermissions
                    .Where(sp => sp.SupplierId == supplier.ID &&
                                 sp.Status == DAL.Entities.Enums.DataStatus.Active)
                    .Select(sp => sp.Permission)
                    .ToList();

                // Token oluştur
                var token = GenerateJwtToken(supplier, permissions);

                _logger.LogInformation($"Supplier giriş yaptı: {supplier.CompanyName} (ID: {supplier.ID})");

                return Ok(new ApiResponse<LoginResponseDTO>
                {
                    Success = true,
                    Message = "Giriş başarılı",
                    Data = new LoginResponseDTO
                    {
                        Token = token,
                        SupplierId = supplier.ID,
                        CompanyName = supplier.CompanyName,
                        Permissions = permissions,
                        ExpiresIn = 3600
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login sırasında hata oluştu");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Giriş yapılırken hata oluştu"
                });
            }
        }

        [HttpGet("supplier-info")]
        public IActionResult GetSupplierInfo()
        {
            try
            {
                //  Veritabanından tüm supplier'ları getir
                var suppliers = _context.Suppliers
                    .Where(s => s.Status == DAL.Entities.Enums.DataStatus.Active &&
                                s.Username != null)  // Sadece username'i olanlar
                    .Select(s => new
                    {
                        Id = s.ID,
                        s.Username,
                        s.CompanyName,
                        s.Email,
                        Password = "Pass123!",
                        Permissions = _context.SupplierPermissions
                            .Where(sp => sp.SupplierId == s.ID &&
                                         sp.Status == DAL.Entities.Enums.DataStatus.Active)
                            .Select(sp => sp.Permission)
                            .ToList()
                    })
                    .ToList();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Test supplier bilgileri",
                    Data = suppliers
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Supplier bilgileri alınırken hata");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Sunucu hatası"
                });
            }
        }

        private string GenerateJwtToken(DAL.Entities.Concretes.Supplier supplier, List<string> permissions)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, supplier.Username),
                new Claim("SupplierId", supplier.ID.ToString()),
                new Claim("CompanyName", supplier.CompanyName),
                new Claim(ClaimTypes.Email, supplier.Email ?? "")
            };

            // Yetkileri claim olarak ekle
            foreach (var permission in permissions)
            {
                claims.Add(new Claim("Permission", permission));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}