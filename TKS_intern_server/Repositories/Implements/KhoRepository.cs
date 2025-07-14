using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Repositories.Implements
{
    public class KhoRepository : IKhoRepository
    {
        private readonly TKS_internContext _context;

        public KhoRepository(TKS_internContext context)
        {
            _context = context;
        }

        public async Task<Kho> CreateAsync(Kho kho)
        {
            await _context.Kho.AddAsync(kho);
            await _context.SaveChangesAsync();
            return kho;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Kho.FindAsync(id);
            if (entity == null)
                return false;

            _context.Kho.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Kho>> GetAllAsync()
        {
            return await _context.Kho
                .OrderByDescending(k => k.UpdatedAt)
                .ToListAsync();
        }

        public async Task<Kho?> GetByIdAsync(int id)
        {
            return await _context.Kho.FindAsync(id);
        }

        public async Task<Kho> UpdateAsync(Kho kho)
        {
            var existing = await _context.Kho.FindAsync(kho.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Không tìm thấy kho với Id = {kho.Id}");

            _context.Entry(existing).CurrentValues.SetValues(kho);
            await _context.SaveChangesAsync();
            return existing;
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.Kho.AnyAsync(k => k.TenKho == name);
        }

        public Task<bool> ExistsByNameAsync(string name, int excludeId)
        {
            return _context.Kho
                .AnyAsync(k => k.TenKho == name && k.Id != excludeId);
        }
    }
}
