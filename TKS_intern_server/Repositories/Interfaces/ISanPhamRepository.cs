using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham?> GetByIdAsync(int id);
        Task<SanPham> CreateAsync(SanPham sanPham);
        Task<SanPham> UpdateAsync(SanPham sanPham);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByMaAsync(string ma);
        Task<bool> ExistsByMaAsync(string ma, int excludeId);

        Task<bool> ExistsByTenAsync(string ten);
        Task<bool> ExistsByTenAsync(string ten, int excludeId);
    }
}
