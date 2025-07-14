using Microsoft.EntityFrameworkCore;
using TKS_intern.Data;
using TKS_intern.Models;
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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.DonViTinh.AnyAsync(d => d.TenDonViTinh == name);
        }

        public Task<IEnumerable<DonViTinh>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DonViTinh?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DonViTinh> UpdateAsync(DonViTinh donViTinh)
        {
            throw new NotImplementedException();
        }
    }
}
