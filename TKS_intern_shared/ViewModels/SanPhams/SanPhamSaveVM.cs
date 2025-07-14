using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.SanPhams
{
    public class SanPhamSaveVM
    {
        [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
        [StringLength(50, ErrorMessage = "Mã sản phẩm không được vượt quá 50 ký tự.")]
        public string MaSanPham { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự.")]
        public string TenSanPham { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn loại sản phẩm.")]
        public int LoaiSanPhamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn đơn vị tính.")]
        public int DonViTinhId { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
        public string? GhiChu { get; set; }
    }
}
