namespace TKS_intern_server.Repositories.Implements
{
    using Microsoft.CodeAnalysis.Scripting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using TKS_intern_server.Data;
    using TKS_intern_server.Repositories.Interfaces;
    using TKS_intern_shared.Models;

    public class AuthRepository : IAuthRepository
    {
        private readonly TKS_internContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(TKS_internContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            // Cập nhật thời gian đăng nhập cuối
            user.LastLoginAt = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

    }

}
