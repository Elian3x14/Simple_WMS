using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.ViewModels.BaoCaos
{
    public class BaoCaoNhapHangVM
    {   
        public DateTime NgayNhap { get; set; }
        public string SoPhieu { get; set; } = string.Empty;
        public string NhaCungCap { get; set; } = string.Empty;
        public string MaSanPham { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }

}
