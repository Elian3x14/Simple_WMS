using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Auth;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameTakenAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
