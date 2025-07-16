using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.PhieuXuatKhos
{
    public class PhieuXuatKhoVM : BaseVM
    {
        public required string SoPhieuXuatKho { get; set; }

        public required int KhoId { get; set; }
        public Kho? Kho { get; set; }
        public required int NhaCungCapId { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
        public required DateTime NgayXuatKho { get; set; }
        public required string? GhiChu { get; set; }

        public IEnumerable<ChiTietPhieuXuatKho>? ChiTietPhieuXuatKhos;
    }
}
