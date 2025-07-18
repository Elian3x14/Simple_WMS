using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.SanPhams;

namespace TKS_intern_shared.ViewModels.ChiTietPhieuNhapKhos
{
    public class ChiTietPhieuNhapKhoVM : BaseVM
    {
        public required int PhieuNhapKhoId { get; set; }
        public PhieuNhapKho? PhieuNhapKho { get; set; }
        public required int SanPhamId { get; set; }
        public SanPhamVM? SanPham { get; set; }
        public required decimal SoLuongNhap { get; set; }
        public required decimal DonGiaNhap { get; set; }
    }
}
