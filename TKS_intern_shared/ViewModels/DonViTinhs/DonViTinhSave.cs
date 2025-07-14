using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.DonViTinhs
{
    public class DonViTinhSave
    {
        [Required(ErrorMessage = "Mã đơn vị tính không được để trống")]
        [StringLength(50, ErrorMessage = "Mã đơn vị tính không được vượt quá 50 ký tự")]
        public string TenDonViTinh { get; set; } = string.Empty;
        public string? GhiChu { get; set; } = null;
    }
}
