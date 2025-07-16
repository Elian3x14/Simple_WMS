using TKS_intern_shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
