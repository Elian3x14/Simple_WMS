using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface INhaCungCapRepository
    {
        Task<IEnumerable<NhaCungCap>> GetAllAsync();
        Task<NhaCungCap?> GetByIdAsync(int id);
        Task<NhaCungCap> CreateAsync(NhaCungCap nhaCungCap);
        Task<NhaCungCap> UpdateAsync(NhaCungCap nhaCungCap);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, int excludeId);
    }
}
