using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_shared.Models;
using TKS_intern_server.Repositories.Interfaces;

namespace TKS_intern_server.Repositories.Implements
{
    public class KhoUserRepository : IKhoUserRepository
    {
        private readonly TKS_internContext _context;

        public KhoUserRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<KhoUser> CreateAsync(KhoUser khoUser)
        {
            await _context.KhoUsers.AddAsync(khoUser);
            await _context.SaveChangesAsync();
            return khoUser;
        }

        public async Task<bool> DeleteAsync(string maDangNhap, int khoId)
        {
            var entity = await _context.KhoUsers
                .FirstOrDefaultAsync(ku => ku.MaDangNhap == maDangNhap && ku.KhoId == khoId);

            if (entity == null)
                return false;

            _context.KhoUsers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<KhoUser>> GetAllAsync()
        {
            return await _context.KhoUsers
                .OrderByDescending(ku => ku.UpdatedAt)
                .ToListAsync();
        }

        public async Task<KhoUser?> GetByKeyAsync(string maDangNhap, int khoId)
        {
            return await _context.KhoUsers
                .FirstOrDefaultAsync(ku => ku.MaDangNhap == maDangNhap && ku.KhoId == khoId);
        }

        public async Task<IEnumerable<KhoUser>> GetByUserAsync(string maDangNhap)
        {
            return await _context.KhoUsers
                .Where(ku => ku.MaDangNhap == maDangNhap)
                .OrderByDescending(ku => ku.UpdatedAt)
                .ToListAsync();
        }

        public Task<bool> ExistsAsync(string maDangNhap, int khoId)
        {
            return _context.KhoUsers
                .AnyAsync(ku => ku.MaDangNhap == maDangNhap && ku.KhoId == khoId);
        }
    }
}
