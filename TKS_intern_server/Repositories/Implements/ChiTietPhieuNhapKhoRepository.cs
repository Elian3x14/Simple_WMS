using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Implements
{
    public class ChiTietPhieuNhapKhoRepository : IChiTietPhieuNhapKhoRepository
    {
        private readonly TKS_internContext _context;

        public ChiTietPhieuNhapKhoRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietPhieuNhapKho>> GetByPhieuNhapKhoIdAsync(int phieuNhapKhoId)
        {
            return await _context.ChiTietPhieuNhapKhos
                 .Where(c => c.PhieuNhapKhoId == phieuNhapKhoId)
                 .Include(c => c.SanPham)
                     .ThenInclude(sp => sp.DonViTinh)
                 .ToListAsync();

        }

        public async Task AddRangeAsync(IEnumerable<ChiTietPhieuNhapKho> details)
        {
            await _context.ChiTietPhieuNhapKhos.AddRangeAsync(details);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteByPhieuNhapKhoIdAsync(int phieuNhapKhoId)
        {
            var items = await _context.ChiTietPhieuNhapKhos
                .Where(c => c.PhieuNhapKhoId == phieuNhapKhoId)
                .ToListAsync();

            if (!items.Any())
                return false;

            _context.ChiTietPhieuNhapKhos.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
