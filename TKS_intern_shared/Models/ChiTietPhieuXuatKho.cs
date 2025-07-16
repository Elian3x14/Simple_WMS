using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class ChiTietPhieuXuatKho: BaseModel
    {
        public required int PhieuXuatKhoId { get; set; }
        public required PhieuXuatKho PhieuXuatKho { get; set; }

        public required int SanPhamId { get; set; }
        public required SanPham SanPham { get; set; }
        public required int SoLuongXuat { get; set; }
        public required decimal DonGiaXuat { get; set; } // Đơn giá xuất kho
    }
}
