using TKS_intern.Models;

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

    }
}
