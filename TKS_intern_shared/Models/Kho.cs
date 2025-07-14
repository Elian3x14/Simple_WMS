using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class Kho : BaseModel
    {
        public required string TenKho { get; set; }
        public string? GhiChu { get; set; }

    }
}
