using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IKhoRepository
    {
        Task<IEnumerable<Kho>> GetAllAsync();
        Task<Kho?> GetByIdAsync(int id);
        Task<Kho> CreateAsync(Kho kho);
        Task<Kho> UpdateAsync(Kho kho);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, int excludeId);
    }
}
