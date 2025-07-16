using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IChiTietPhieuXuatKhoRepository
    {
        Task<IEnumerable<ChiTietPhieuXuatKho>> GetByPhieuXuatKhoIdAsync(int phieuXuatKhoId);
        Task AddRangeAsync(IEnumerable<ChiTietPhieuXuatKho> details);
        Task<bool> DeleteByPhieuXuatKhoIdAsync(int phieuXuatKhoId);
    }
}
