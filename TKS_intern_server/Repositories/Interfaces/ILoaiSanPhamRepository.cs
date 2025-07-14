using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface ILoaiSanPhamRepository
    {
        Task<IEnumerable<LoaiSanPham>> GetAllAsync();
        Task<LoaiSanPham?> GetByIdAsync(int id);
        Task<LoaiSanPham> CreateAsync(LoaiSanPham loaiSanPham);
        Task<LoaiSanPham> UpdateAsync(LoaiSanPham loaiSanPham);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByMaAsync(string ma);
        Task<bool> ExistsByMaAsync(string ma, int excludeId);

        Task<bool> ExistsByTenAsync(string ten);
        Task<bool> ExistsByTenAsync(string ten, int excludeId);
    }
}
