
using TKS_intern_shared.Models;

namespace TKS_intern.Repositories.Interfaces
{
    public interface IDonViTinhRepository
    {
        Task<IEnumerable<DonViTinh>> GetAllAsync();
        Task<DonViTinh?> GetByIdAsync(int id);
        Task<DonViTinh> CreateAsync(DonViTinh donViTinh);
        Task<DonViTinh> UpdateAsync(DonViTinh donViTinh);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, int excludeId);
    }
}
