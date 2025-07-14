using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.KhoUsers
{
    public class KhoUserVM: BaseVM
    {
        public required string MaDangNhap { get; set; }
        public required int KhoId { get; set; }
        public required Kho Kho { get; set; }
    }
}
