using Microsoft.EntityFrameworkCore;
using TKS_intern.Data;
using TKS_intern_shared.Models;
using TKS_intern.Repositories.Interfaces;

namespace TKS_intern.Repositories.Implements
{
    public class DonViTinhRepository : IDonViTinhRepository
    {
        private readonly TKS_internContext _context;
        public DonViTinhRepository( TKS_internContext context)
        {
            _context = context;
        }

        public async Task<DonViTinh> CreateAsync(DonViTinh donViTinh)
        {
            await _context.AddAsync(donViTinh);
            await _context.SaveChangesAsync();
            return donViTinh;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DonViTinh.FindAsync(id);

            if (entity == null)
            {
                return false; // Không tìm thấy -> báo lỗi 404 ở controller
            }

            _context.DonViTinh.Remove(entity);
            await _context.SaveChangesAsync();

            return true; // Xóa thành công
        }


        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.DonViTinh.AnyAsync(d => d.TenDonViTinh == name);
        }

        public Task<bool> ExistsByNameAsync(string name, int excludeId)
        {
            return _context.DonViTinh
                .AnyAsync(d => d.TenDonViTinh == name && d.Id != excludeId);
        }

        public async Task<IEnumerable<DonViTinh>> GetAllAsync()
        {
            return await _context.DonViTinh
                .OrderByDescending(d => d.UpdatedAt) // Ưu tiên bản ghi gần đây nhất
                .ToListAsync();
        }
        public async Task<DonViTinh?> GetByIdAsync(int id)
        {
            return await _context.DonViTinh.FindAsync(id);
        }

        public async Task<DonViTinh> UpdateAsync(DonViTinh donViTinh)
        {
            var existing = await _context.DonViTinh.FindAsync(donViTinh.Id);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy đơn vị tính với Id = {donViTinh.Id}");
            }

            _context.Entry(existing).CurrentValues.SetValues(donViTinh);

            await _context.SaveChangesAsync();

            return existing;
        }

    }
}
