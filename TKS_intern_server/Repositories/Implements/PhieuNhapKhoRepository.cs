using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.BaoCaos;

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

        public async Task<List<BaoCaoNhapHangVM>> GetBaoCaoNhapHangAsync(DateTime tuNgay, DateTime denNgay)
        {
            var result = await _context.PhieuNhapKhos
                .Include(p => p.NhaCungCap)
                .Include(p => p.ChiTietPhieuNhapKhos)
                    .ThenInclude(ct => ct.SanPham)
                .Where(p => p.NgayNhapKho.Date >= tuNgay.Date && p.NgayNhapKho.Date <= denNgay.Date)
                .SelectMany(p => p.ChiTietPhieuNhapKhos.Select(ct => new BaoCaoNhapHangVM
                {
                    NgayNhap = p.NgayNhapKho,
                    SoPhieu = p.SoPhieuNhapKho,
                    NhaCungCap = p.NhaCungCap!.TenNhaCungCap,
                    MaSanPham = ct.SanPham.MaSanPham,
                    TenSanPham = ct.SanPham.TenSanPham,
                    SoLuong = ct.SoLuongNhap,
                    DonGia = ct.DonGiaNhap
                }))
                .ToListAsync();

            return result;
        }

        public async Task<PhieuNhapKho> UpdateAsync(PhieuNhapKho phieuNhapKho)
        {
            var existing = await _context.PhieuNhapKhos.FindAsync(phieuNhapKho.Id);
            if (existing == null)
                throw new InvalidOperationException("Phiếu nhập kho không tồn tại.");

            // Cập nhật các trường
            existing.SoPhieuNhapKho = phieuNhapKho.SoPhieuNhapKho;
            existing.KhoId = phieuNhapKho.KhoId;
            existing.NhaCungCapId = phieuNhapKho.NhaCungCapId;
            existing.NgayNhapKho = phieuNhapKho.NgayNhapKho;
            existing.GhiChu = phieuNhapKho.GhiChu;

            // Có thể cập nhật thêm các navigation property nếu cần

            _context.PhieuNhapKhos.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
