using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Implements
{
    public class PhieuNhapKhoRepository : IPhieuNhapKhoRepository
    {
        private readonly TKS_internContext _context;

        public PhieuNhapKhoRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<PhieuNhapKho> CreateAsync(PhieuNhapKho phieuNhapKho)
        {
            await _context.AddAsync(phieuNhapKho);
            await _context.SaveChangesAsync();
            return phieuNhapKho;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PhieuNhapKhos.FindAsync(id);
            if (entity == null)
                return false;

            _context.PhieuNhapKhos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhieuNhapKho>> GetAllAsync()
        {
            return await _context.PhieuNhapKhos
                .Include(p => p.Kho)
                .Include(p => p.NhaCungCap)
                .OrderByDescending(p => p.NgayNhapKho)
                .ToListAsync();
        }

        public async Task<PhieuNhapKho?> GetByIdAsync(int id)
        {
            return await _context.PhieuNhapKhos
                .Include(p => p.Kho)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> ExistsBySoPhieuAsync(string soPhieuNhap)
        {
            return _context.PhieuNhapKhos.AnyAsync(p => p.SoPhieuNhapKho == soPhieuNhap);
        }

        public Task<bool> ExistsBySoPhieuAsync(string soPhieuNhap, int excludeId)
        {
            return _context.PhieuNhapKhos
                .AnyAsync(p => p.SoPhieuNhapKho == soPhieuNhap && p.Id != excludeId);
        }
    }
}
