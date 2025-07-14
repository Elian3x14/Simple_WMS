using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.Khos
{
    public class KhoSaveVM
    {
        [Required(ErrorMessage = "Tên kho không được để trống.")]
        [StringLength(255, ErrorMessage = "Tên kho không được vượt quá 255 ký tự.")]
        public string TenKho { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự.")]
        public string? GhiChu { get; set; } 
    }
}
