using System.Collections.Generic;
using System.Threading.Tasks;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.BaoCaos;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IPhieuXuatKhoRepository
    {
        Task<IEnumerable<PhieuXuatKho>> GetAllAsync();
        Task<PhieuXuatKho?> GetByIdAsync(int id);
        Task<PhieuXuatKho> CreateAsync(PhieuXuatKho phieuXuatKho);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsBySoPhieuAsync(string soPhieuXuat);
        Task<bool> ExistsBySoPhieuAsync(string soPhieuXuat, int excludeId);

        Task<List<BaoCaoXuatHangVM>> GetBaoCaoXuatHangAsync(DateTime tuNgay, DateTime denNgay);

    }
}
