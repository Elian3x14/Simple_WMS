using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IChiTietPhieuNhapKhoRepository
    {
        Task<IEnumerable<ChiTietPhieuNhapKho>> GetByPhieuNhapKhoIdAsync(int phieuNhapKhoId);
        Task AddRangeAsync(IEnumerable<ChiTietPhieuNhapKho> details);
        Task<bool> DeleteByPhieuNhapKhoIdAsync(int phieuNhapKhoId);
    }
}
