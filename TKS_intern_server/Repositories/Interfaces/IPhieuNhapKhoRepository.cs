using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IPhieuNhapKhoRepository
    {
        Task<IEnumerable<PhieuNhapKho>> GetAllAsync();
        Task<PhieuNhapKho?> GetByIdAsync(int id);
        Task<PhieuNhapKho> CreateAsync(PhieuNhapKho phieuNhapKho);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsBySoPhieuAsync(string soPhieuNhap);
        Task<bool> ExistsBySoPhieuAsync(string soPhieuNhap, int excludeId);
    }
}
