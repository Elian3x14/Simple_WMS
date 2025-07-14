using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.Models
{
    public class KhoUser : BaseModel
    {
        public required string MaDangNhap { get; set; }
        public required int KhoId { get; set; }
        public required Kho Kho { get; set; }

        // Thêm quyền, vai trò , hoặc thông tin khác nếu cần
    }
}
