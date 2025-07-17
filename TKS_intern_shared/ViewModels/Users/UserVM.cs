using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_intern_shared.Enums;

namespace TKS_intern_shared.ViewModels.Users
{
    public class UserVM : BaseVM
    {
        public required string UserName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? FullName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginAt { get; set; }

        public UserRole Role { get; set; } = UserRole.Guest;
    }
}
