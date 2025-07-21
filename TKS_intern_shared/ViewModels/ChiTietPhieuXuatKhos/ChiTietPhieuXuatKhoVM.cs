using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.PhieuXuatKhos;
using TKS_intern_shared.ViewModels.SanPhams;

namespace TKS_intern_shared.ViewModels.ChiTietPhieuXuatKhos
{
    public class ChiTietPhieuXuatKhoVM : BaseVM
    {
        public required int PhieuXuatKhoId { get; set; }
        public PhieuXuatKhoVM? PhieuXuatKho { get; set; }

        public required int SanPhamId { get; set; }
        public required SanPhamVM SanPham { get; set; }
        public required int SoLuongXuat { get; set; }
        public required decimal DonGiaXuat { get; set; }
    }
}
