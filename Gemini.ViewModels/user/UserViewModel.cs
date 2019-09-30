using System.ComponentModel.DataAnnotations;

namespace Gemini.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "用户名最少5个字符")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "密码最少6个字符")]
        [MaxLength(12, ErrorMessage = "密码最多12个字符")]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = "密码最少6个字符")]
        [MaxLength(12, ErrorMessage = "密码最多12个字符")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        public string RealName { get; set; }

        [Phone(ErrorMessage = "请填写正确的手机号码")]
        public string Mobile { get; set; }
    }
}
