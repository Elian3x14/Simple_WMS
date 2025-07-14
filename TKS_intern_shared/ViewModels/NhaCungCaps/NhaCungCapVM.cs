using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.ViewModels.NhaCungCaps
{
    public class NhaCungCapVM : BaseVM
    {
        public required string MaNhaCungCap { get; set; }
        public required string TenNhaCungCap { get; set; }

        public string? GhiChu { get; set; }
    }
}
