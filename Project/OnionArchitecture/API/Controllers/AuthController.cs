using Application.DTOs.UserDTOs;
using Application.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserServiceManager _userServiceManager;
        public AuthController(UserServiceManager userServiceManager)
        {
            _userServiceManager = userServiceManager;
        }
        // Kullanıcı kaydı oluştur

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userServiceManager.RegisterUserAsync(model);

            if (result.Success)
                return Ok(new { message = result.Message });

            return BadRequest(new { message = result.Message, errors = result.Errors });
        }
        // Login - Kullanıcı giriş yapar ve token alır
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userServiceManager.LoginAsync(model);
            if (result.Success)
                return Ok(result.Data);
            return Unauthorized(new { message = result.Message });

        }
        //token geçerliliğini kontrol et
        [HttpGet("validate-token")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            var userName = User.Identity?.Name;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(new
            {
                message = "Token geçerli",
                userName = userName,
                userId = userId
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userServiceManager.LogoutUserAsync();
            return Ok(new { message = "Çıkış başarılı!" });
        }

    }
}
