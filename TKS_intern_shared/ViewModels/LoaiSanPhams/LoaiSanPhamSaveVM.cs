using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.LoaiSanPhams
{
    public class LoaiSanPhamSaveVM
    {
        [Required(ErrorMessage = "Mã loại sản phẩm không được để trống")]
        [StringLength(50, ErrorMessage = "Mã loại sản phẩm không được vượt quá 50 ký tự")]
        public string MaLoaiSanPham { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(255, ErrorMessage = "Tên loại sản phẩm không được vượt quá 255 ký tự")]
        public string TenLoaiSanPham { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string GhiChu { get; set; } = string.Empty;
    }
}
