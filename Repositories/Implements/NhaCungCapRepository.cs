using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_shared.Models;
using TKS_intern_server.Repositories.Interfaces;

namespace TKS_intern_server.Repositories.Implements
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly TKS_internContext _context;

        public NhaCungCapRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<NhaCungCap> CreateAsync(NhaCungCap nhaCungCap)
        {
            await _context.NhaCungCap.AddAsync(nhaCungCap);
            await _context.SaveChangesAsync();
            return nhaCungCap;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.NhaCungCap.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.NhaCungCap.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NhaCungCap>> GetAllAsync()
        {
            return await _context.NhaCungCap
                .OrderByDescending(n => n.UpdatedAt)
                .ToListAsync();
        }

        public async Task<NhaCungCap?> GetByIdAsync(int id)
        {
            return await _context.NhaCungCap.FindAsync(id);
        }

        public async Task<NhaCungCap> UpdateAsync(NhaCungCap nhaCungCap)
        {
            var existing = await _context.NhaCungCap.FindAsync(nhaCungCap.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy nhà cung cấp với Id = {nhaCungCap.Id}");
            }

            _context.Entry(existing).CurrentValues.SetValues(nhaCungCap);
            await _context.SaveChangesAsync();

            return existing;
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.NhaCungCap.AnyAsync(n => n.TenNhaCungCap == name);
        }

        public Task<bool> ExistsByNameAsync(string name, int excludeId)
        {
            return _context.NhaCungCap
                .AnyAsync(n => n.TenNhaCungCap == name && n.Id != excludeId);
        }

        public Task<bool> ExistsByMaAsync(string maNhaCungCap)
        {
            return _context.NhaCungCap
                .AnyAsync(n => n.MaNhaCungCap == maNhaCungCap);
        }

        public Task<bool> ExistsByMaAsync(string maNhaCungCap, int excludeId)
        {
            return _context.NhaCungCap
                .AnyAsync(n => n.MaNhaCungCap == maNhaCungCap && n.Id != excludeId);
        }

    }
}
