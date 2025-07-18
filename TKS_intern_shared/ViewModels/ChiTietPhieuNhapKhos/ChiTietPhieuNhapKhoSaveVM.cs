using System.ComponentModel.DataAnnotations;
using TKS_intern_shared.ViewModels.SanPhams;

namespace TKS_intern_shared.ViewModels.ChiTietPhieuNhapKhos
{
    public class ChiTietPhieuNhapKhoSaveVM
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "PhieuNhapKhoId là bắt buộc.")]
        public int PhieuNhapKhoId { get; set; }

        [Required(ErrorMessage = "SanPhamId là bắt buộc.")]
        public int SanPhamId { get; set; }
        public SanPhamVM? SanPham { get; set; }

        [Required(ErrorMessage = "Số lượng nhập là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0.")]
        public decimal SoLuongNhap { get; set; }

        [Required(ErrorMessage = "Đơn giá nhập là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá nhập phải lớn hơn 0.")]
        public decimal DonGiaNhap { get; set; }
    }
}
