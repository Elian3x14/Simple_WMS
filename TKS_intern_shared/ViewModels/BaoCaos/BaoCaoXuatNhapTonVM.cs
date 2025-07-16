using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.ViewModels.BaoCaos
{
    public class BaoCaoXuatNhapTonVM
    {
        public string MaSanPham { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public decimal SoLuongDauKy { get; set; }
        public decimal SoLuongNhap { get; set; }
        public decimal SoLuongXuat { get; set; }
        public decimal SoLuongCuoiKy => SoLuongDauKy + SoLuongNhap - SoLuongXuat;
    }

}
