using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class SanPham : BaseModel
    {
        public required string MaSanPham { get; set; }
        public required string TenSanPham { get; set; }
        public required int LoaiSanPhamId { get; set; }
        public required LoaiSanPham LoaiSanPham { get; set;}
        public required int DonViTinhId { get; set; }
        public required DonViTinh DonViTinh { get; set; }

        public string? GhiChu { get; set; }

    }
}
