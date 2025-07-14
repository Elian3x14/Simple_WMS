using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.NhaCungCaps
{
    public class NhaCungCapSaveVM
    {
        [Required(ErrorMessage = "Mã nhà cung cấp là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Mã nhà cung cấp không được vượt quá 50 ký tự.")]
        public string MaNhaCungCap { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc.")]
        [StringLength(255, ErrorMessage = "Tên nhà cung cấp không được vượt quá 255 ký tự.")]
        public string TenNhaCungCap { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
        public string? GhiChu { get; set; }
    }
}
