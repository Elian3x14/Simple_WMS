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
        public int? LoaiSanPhamId { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set;}
        public int? DonViTinhId { get; set; }
        public DonViTinh? DonViTinh { get; set; }

        public string? GhiChu { get; set; }

    }
}
