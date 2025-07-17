using TKS_intern_shared.Enums;

namespace TKS_intern_shared.Models
{
    public class User : BaseModel
    {

        public required string UserName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? FullName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginAt { get; set; }

        public UserRole Role { get; set; } = UserRole.Guest;
    }
}
