using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TKS_intern_shared.ViewModels.Khos;
using TKS_intern_shared.ViewModels.Users;

namespace TKS_intern_shared.ViewModels.KhoUsers
{
    public class KhoUserSaveVM
    {
        [Required(ErrorMessage = "Mã đăng nhập là bắt buộc")]
        [StringLength(50, ErrorMessage = "Mã đăng nhập không được vượt quá 50 ký tự")]
        public string MaDangNhap { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn kho")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn kho hợp lệ")]
        public int KhoId { get; set; }

        [JsonIgnore]
        public KhoVM? Kho { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn người dùng")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn người dùng hợp lệ")]
        public int UserId { get; set; }
        [JsonIgnore]
        public UserVM? User { get; set; }
    }
}
