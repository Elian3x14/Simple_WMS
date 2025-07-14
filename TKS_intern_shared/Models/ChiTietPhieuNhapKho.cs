using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class ChiTietPhieuNhapKho : BaseModel
    {
        public required int PhieuNhapKhoId { get; set; }
        public PhieuNhapKho? PhieuNhapKho { get; set; }
        public required int SanPhamId { get; set; }
        public SanPham? SanPham { get; set; }
        public required decimal SoLuongNhap { get; set; }
        public required decimal DonGiaNhap { get; set; }
    }
}
