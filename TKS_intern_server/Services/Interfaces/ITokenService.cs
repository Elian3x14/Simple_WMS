using TKS_intern_shared.Models;

namespace TKS_intern_server.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
