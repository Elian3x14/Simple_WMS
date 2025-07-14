using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.PhieuNhapKhos
{
    public class PhieuNhapKhoVM : BaseVM
    {
        public required string SoPhieuNhapKho { get; set; }
        public required int KhoId { get; set; }
        public Kho? Kho { get; set; }
        public required int NhaCungCapId { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
        public required DateTime NgayNhapKho { get; set; }
        public required string? GhiChu { get; set; }

        public IEnumerable<ChiTietPhieuNhapKho>? ChiTietPhieuNhapKhos;

    }
}
