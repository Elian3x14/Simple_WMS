using System.ComponentModel.DataAnnotations;

namespace TKS_intern_shared.ViewModels.Auth
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        [MinLength(4, ErrorMessage = "Tên đăng nhập phải có ít nhất 4 ký tự.")]
        [MaxLength(20, ErrorMessage = "Tên đăng nhập không được vượt quá 20 ký tự.")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        [MaxLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
        public required string Password { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string? Email { get; set; }

        [MaxLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string? FullName { get; set; }
    }
}
