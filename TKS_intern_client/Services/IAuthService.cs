using TKS_intern_shared.ViewModels.Auth;

namespace TKS_intern_client.Services
{
    public interface IAuthService
    {
        Task<TokenVM?> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();
    }
}
