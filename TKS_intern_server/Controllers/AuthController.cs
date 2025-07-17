using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_server.Services.Interfaces;
using TKS_intern_shared.Enums;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Auth;

namespace TKS_intern_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITokenService _tokenService;

        public AuthController(
            IAuthRepository authRepo,
            ITokenService tokenService)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
            var user = await _authRepo.AuthenticateAsync(login.Username, login.Password);
            if (user == null)
                return Unauthorized(
                    new { Message = "Tên đăng nhập hoặc mật khẩu không đúng." }
                );

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM register)
        {
            // Kiểm tra user đã tồn tại chưa
            var existingUser = await _authRepo.GetByUsernameAsync(register.UserName);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Tên đăng nhập đã được sử dụng." });
            }


            var newUser = new User
            {
                UserName = register.UserName,
                PasswordHash = register.Password,
                Email = register.Email ?? string.Empty,
                FullName = register.FullName,
                IsActive = true,
                Role = UserRole.Guest
            };

            await _authRepo.CreateUserAsync(newUser);

            return Ok(new { Message = "Đăng ký thành công." });
        }

    }
}
