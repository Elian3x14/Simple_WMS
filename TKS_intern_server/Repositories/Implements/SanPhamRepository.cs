using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_shared.Models;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.ViewModels.BaoCaos;

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
            await _context.SanPhams.AddAsync(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }

        public async Task<SanPham?> GetByIdAsync(int id)
        {
            return await _context.SanPhams
                .Include(sp => sp.LoaiSanPham)
                .Include(sp => sp.DonViTinh)
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams
                .Include(sp => sp.LoaiSanPham)
                .Include(sp => sp.DonViTinh)
                .OrderByDescending(sp => sp.UpdatedAt)
                .ToListAsync();
        }

        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            var existing = await _context.SanPhams.FindAsync(sanPham.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Không tìm thấy sản phẩm với Id = {sanPham.Id}");

            _context.Entry(existing).CurrentValues.SetValues(sanPham);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.SanPhams.FindAsync(id);
            if (entity == null) return false;

            _context.SanPhams.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> ExistsByMaAsync(string ma)
        {
            return _context.SanPhams.AnyAsync(sp => sp.MaSanPham == ma);
        }

        public Task<bool> ExistsByMaAsync(string ma, int excludeId)
        {
            return _context.SanPhams.AnyAsync(sp => sp.MaSanPham == ma && sp.Id != excludeId);
        }

        public Task<bool> ExistsByTenAsync(string ten)
        {
            return _context.SanPhams.AnyAsync(sp => sp.TenSanPham == ten);
        }

        public Task<bool> ExistsByTenAsync(string ten, int excludeId)
        {
            return _context.SanPhams.AnyAsync(sp => sp.TenSanPham == ten && sp.Id != excludeId);
        }

        public async Task<List<BaoCaoXuatNhapTonVM>> GetBaoCaoXuatNhapTonAsync(BaoCaoXuatNhapTonFilter filter)
        {
            var sanPhams = await _context.SanPhams.Include(x => x.DonViTinh).ToListAsync();

            var tuNgay = filter.TuNgay.Date;
            var denNgay = filter.DenNgay.Date.AddDays(1).AddTicks(-1); // tới cuối ngày

            var nhaps = await _context.ChiTietPhieuNhapKhos
                .Where(c => c.PhieuNhapKho.NgayNhapKho >= tuNgay && c.PhieuNhapKho.NgayNhapKho <= denNgay)
                .ToListAsync();

            var xuats = await _context.ChiTietPhieuXuatKhos
                .Where(c => c.PhieuXuatKho.NgayXuatKho >= tuNgay && c.PhieuXuatKho.NgayXuatKho <= denNgay)
                .ToListAsync();

            var result = new List<BaoCaoXuatNhapTonVM>();

            foreach (var sp in sanPhams)
            {
                var slNhap = nhaps.Where(x => x.SanPhamId == sp.Id).Sum(x => x.SoLuongNhap);
                var slXuat = xuats.Where(x => x.SanPhamId == sp.Id).Sum(x => x.SoLuongXuat);

                // Giả sử SL Đầu kỳ là 0, nếu có bảng tồn kho thì truy vấn thêm ở đây
                var slDauKy = 0;

                result.Add(new BaoCaoXuatNhapTonVM
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    SoLuongDauKy = slDauKy,
                    SoLuongNhap = slNhap,
                    SoLuongXuat = slXuat
                });
            }

            return result;
        }

    }
}
