using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> AuthenticateAsync(string username, string password);

        Task<User?> GetByUsernameAsync(string username);
        Task CreateUserAsync(User user);

    }

}
