using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class PhieuXuatKho : BaseModel
    {
        public required string SoPhieuXuatKho { get; set; }

        public required int KhoId { get; set; }
        public Kho? Kho { get; set; }
        public required DateTime NgayXuatKho { get; set; }
        public required string? GhiChu { get; set; }

        public required IEnumerable<ChiTietPhieuXuatKho> ChiTietPhieuXuatKhos;

    }
}
