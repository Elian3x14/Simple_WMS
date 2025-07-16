using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Implements
{
    public class PhieuXuatKhoRepository : IPhieuXuatKhoRepository
    {
        private readonly TKS_internContext _context;

        public PhieuXuatKhoRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<PhieuXuatKho> CreateAsync(PhieuXuatKho phieuXuatKho)
        {
            await _context.AddAsync(phieuXuatKho);
            await _context.SaveChangesAsync();
            return phieuXuatKho;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PhieuXuatKhos.FindAsync(id);
            if (entity == null)
                return false;

            _context.PhieuXuatKhos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhieuXuatKho>> GetAllAsync()
        {
            return await _context.PhieuXuatKhos
                .Include(p => p.Kho)
                .OrderByDescending(p => p.NgayXuatKho)
                .ToListAsync();
        }

        public async Task<PhieuXuatKho?> GetByIdAsync(int id)
        {
            return await _context.PhieuXuatKhos
                .Include(p => p.Kho)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> ExistsBySoPhieuAsync(string soPhieuXuat)
        {
            return _context.PhieuXuatKhos.AnyAsync(p => p.SoPhieuXuatKho == soPhieuXuat);
        }

        public Task<bool> ExistsBySoPhieuAsync(string soPhieuXuat, int excludeId)
        {
            return _context.PhieuXuatKhos
                .AnyAsync(p => p.SoPhieuXuatKho == soPhieuXuat && p.Id != excludeId);
        }
    }
}
