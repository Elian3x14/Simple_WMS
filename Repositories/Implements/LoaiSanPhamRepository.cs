using Microsoft.EntityFrameworkCore;
using TKS_intern_shared.Data;
using TKS_intern_shared.Models;
using TKS_intern_shared.Repositories.Interfaces;

namespace TKS_intern_shared.Repositories.Implements
{
    public class LoaiSanPhamRepository : ILoaiSanPhamRepository
    {
        private readonly TKS_internContext _context;

        public LoaiSanPhamRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<LoaiSanPham> CreateAsync(LoaiSanPham loaiSanPham)
        {
            await _context.LoaiSanPham.AddAsync(loaiSanPham);
            await _context.SaveChangesAsync();
            return loaiSanPham;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.LoaiSanPham.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.LoaiSanPham.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsByMaAsync(string ma)
        {
            return await _context.LoaiSanPham.AnyAsync(x => x.MaLoaiSanPham == ma);
        }

        public async Task<bool> ExistsByMaAsync(string ma, int excludeId)
        {
            return await _context.LoaiSanPham.AnyAsync(x => x.MaLoaiSanPham == ma && x.Id != excludeId);
        }

        public async Task<bool> ExistsByTenAsync(string ten)
        {
            return await _context.LoaiSanPham.AnyAsync(x => x.TenLoaiSanPham == ten);
        }

        public async Task<bool> ExistsByTenAsync(string ten, int excludeId)
        {
            return await _context.LoaiSanPham.AnyAsync(x => x.TenLoaiSanPham == ten && x.Id != excludeId);
        }

        public async Task<IEnumerable<LoaiSanPham>> GetAllAsync()
        {
            return await _context.LoaiSanPham
                .OrderByDescending(x => x.UpdatedAt)
                .ToListAsync();
        }

        public async Task<LoaiSanPham?> GetByIdAsync(int id)
        {
            return await _context.LoaiSanPham.FindAsync(id);
        }

        public async Task<LoaiSanPham> UpdateAsync(LoaiSanPham loaiSanPham)
        {
            var existing = await _context.LoaiSanPham.FindAsync(loaiSanPham.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy loại sản phẩm với Id = {loaiSanPham.Id}");
            }

            _context.Entry(existing).CurrentValues.SetValues(loaiSanPham);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
