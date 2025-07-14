using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.ViewModels.LoaiSanPhams
{
    public class LoaiSanPhamVM : BaseVM
    {
        public string MaLoaiSanPham { get; set; } = string.Empty;

        public string TenLoaiSanPham { get; set; } = string.Empty;

        public string GhiChu { get; set; } = string.Empty;
    }
}
