using System;
using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.PhieuNhapKhos
{
    public class PhieuNhapKhoSaveVM
    {
        [Required(ErrorMessage = "Số phiếu nhập kho là bắt buộc.")]
        [MaxLength(50, ErrorMessage = "Số phiếu nhập kho không được vượt quá 50 ký tự.")]
        public string SoPhieuNhapKho { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kho là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Kho không hợp lệ.")]
        public int KhoId { get; set; }

        [Required(ErrorMessage = "Nhà cung cấp là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhà cung cấp không hợp lệ.")]
        public int NhaCungCapId { get; set; }

        [Required(ErrorMessage = "Ngày nhập kho là bắt buộc.")]
        public DateTime NgayNhapKho { get; set; }

        [MaxLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
        public string? GhiChu { get; set; }
    }
}
