using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TKS_intern_server.Services.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Services.Implements
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (_configuration == null)
                throw new InvalidOperationException("Configuration is not set.");

            string? keyStr = _configuration["JwtSettings:Key"];
            string? issuer = _configuration["JwtSettings:Issuer"];
            string? audience = _configuration["JwtSettings:Audience"];
            string? expiresInStr = _configuration["JwtSettings:ExpiresInMinutes"];

            if (string.IsNullOrEmpty(keyStr))
                throw new InvalidOperationException("JWT key is not configured.");
            if (string.IsNullOrEmpty(issuer))
                throw new InvalidOperationException("JWT issuer is not configured.");
            if (string.IsNullOrEmpty(audience))
                throw new InvalidOperationException("JWT audience is not configured.");
            if (string.IsNullOrEmpty(expiresInStr))
                throw new InvalidOperationException("JWT expiration time is not configured.");

            if (!double.TryParse(expiresInStr, out double expiresInMinutes))
                throw new InvalidOperationException("JWT expiration time is invalid.");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(expiresInMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
