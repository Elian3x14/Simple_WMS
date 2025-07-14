using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.SanPhams
{
    public class SanPhamVM : BaseVM
    {
        public required string MaSanPham { get; set; }
        public required string TenSanPham { get; set; }
        public required int LoaiSanPhamId { get; set; }
        public required LoaiSanPham LoaiSanPham { get; set; }
        public required int DonViTinhId { get; set; }
        public required DonViTinh DonViTinh { get; set; }

        public string? GhiChu { get; set; }
    }
}
