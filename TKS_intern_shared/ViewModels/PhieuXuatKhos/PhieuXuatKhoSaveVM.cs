using System;
using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.PhieuXuatKhos
{
    public class PhieuXuatKhoSaveVM
    {
        [Required(ErrorMessage = "Số phiếu xuất kho là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Số phiếu xuất kho không được vượt quá 50 ký tự.")]
        public string SoPhieuXuatKho { get; set; } = null!;

        [Required(ErrorMessage = "Kho là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Kho không hợp lệ.")]
        public int KhoId { get; set; }

        [Required(ErrorMessage = "Nhà cung cấp là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhà cung cấp không hợp lệ.")]
        public int NhaCungCapId { get; set; }

        [Required(ErrorMessage = "Ngày xuất kho là bắt buộc.")]
        [DataType(DataType.Date, ErrorMessage = "Ngày xuất kho không hợp lệ.")]
        public DateTime NgayXuatKho { get; set; }

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự.")]
        public string? GhiChu { get; set; }
    }
}
