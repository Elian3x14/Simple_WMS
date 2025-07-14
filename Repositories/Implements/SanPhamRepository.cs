using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_shared.Models;
using TKS_intern_server.Repositories.Interfaces;

namespace TKS_intern_shared.Repositories.Implements
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly TKS_internContext _context;

        public SanPhamRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<SanPham> CreateAsync(SanPham sanPham)
        {
            await _context.SanPham.AddAsync(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }

        public async Task<SanPham?> GetByIdAsync(int id)
        {
            return await _context.SanPham
                .Include(sp => sp.LoaiSanPham)
                .Include(sp => sp.DonViTinh)
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPham
                .Include(sp => sp.LoaiSanPham)
                .Include(sp => sp.DonViTinh)
                .OrderByDescending(sp => sp.UpdatedAt)
                .ToListAsync();
        }

        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            var existing = await _context.SanPham.FindAsync(sanPham.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Không tìm thấy sản phẩm với Id = {sanPham.Id}");

            _context.Entry(existing).CurrentValues.SetValues(sanPham);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.SanPham.FindAsync(id);
            if (entity == null) return false;

            _context.SanPham.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> ExistsByMaAsync(string ma)
        {
            return _context.SanPham.AnyAsync(sp => sp.MaSanPham == ma);
        }

        public Task<bool> ExistsByMaAsync(string ma, int excludeId)
        {
            return _context.SanPham.AnyAsync(sp => sp.MaSanPham == ma && sp.Id != excludeId);
        }

        public Task<bool> ExistsByTenAsync(string ten)
        {
            return _context.SanPham.AnyAsync(sp => sp.TenSanPham == ten);
        }

        public Task<bool> ExistsByTenAsync(string ten, int excludeId)
        {
            return _context.SanPham.AnyAsync(sp => sp.TenSanPham == ten && sp.Id != excludeId);
        }
    }
}
