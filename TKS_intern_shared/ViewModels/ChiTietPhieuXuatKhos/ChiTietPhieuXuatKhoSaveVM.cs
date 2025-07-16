using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.ChiTietPhieuXuatKhos
{
    public class ChiTietPhieuXuatKhoSaveVM
    {
        [Required(ErrorMessage = "PhieuXuatKhoId là bắt buộc.")]
        public int PhieuXuatKhoId { get; set; }

        [Required(ErrorMessage = "SanPhamId là bắt buộc.")]
        public int SanPhamId { get; set; }

        // SanPham là object liên kết, không nên bắt required trong ViewModel Save
        [JsonIgnore]
        public SanPham? SanPham { get; set; }

        [Required(ErrorMessage = "Số lượng xuất là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng xuất phải lớn hơn 0.")]
        public int SoLuongXuat { get; set; }

        [Required(ErrorMessage = "Đơn giá xuất là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá xuất phải lớn hơn 0.")]
        public decimal DonGiaXuat { get; set; }
    }
}
