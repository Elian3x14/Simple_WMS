using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Interfaces
{
    public interface IKhoUserRepository
    {
        Task<IEnumerable<KhoUser>> GetAllAsync();
        Task<IEnumerable<KhoUser>> GetByUserAsync(string maDangNhap);
        Task<KhoUser?> GetByKeyAsync(string maDangNhap, int khoId);
        Task<KhoUser> CreateAsync(KhoUser khoUser);
        Task<bool> DeleteAsync(string maDangNhap, int khoId);
        Task<bool> ExistsAsync(string maDangNhap, int khoId);
        Task<IEnumerable<KhoUser>> GetByKhoAsync(int khoId);
    }
}
