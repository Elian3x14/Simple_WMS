using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Implements
{
    public class ChiTietPhieuXuatKhoRepository : IChiTietPhieuXuatKhoRepository
    {
        private readonly TKS_internContext _context;

        public ChiTietPhieuXuatKhoRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietPhieuXuatKho>> GetByPhieuXuatKhoIdAsync(int phieuXuatKhoId)
        {
            return await _context.ChiTietPhieuXuatKhos
                 .Where(c => c.PhieuXuatKhoId == phieuXuatKhoId)
                 .Include(c => c.SanPham)
                     .ThenInclude(sp => sp.DonViTinh)
                 .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<ChiTietPhieuXuatKho> details)
        {
            await _context.ChiTietPhieuXuatKhos.AddRangeAsync(details);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteByPhieuXuatKhoIdAsync(int phieuXuatKhoId)
        {
            var items = await _context.ChiTietPhieuXuatKhos
                .Where(c => c.PhieuXuatKhoId == phieuXuatKhoId)
                .ToListAsync();

            if (!items.Any())
                return false;

            _context.ChiTietPhieuXuatKhos.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
