using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gemini.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(6,ErrorMessage ="最少6个字符")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "最少6个字符")]
        [MaxLength(12, ErrorMessage = "最多12个字符")]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = "最少6个字符")]
        [MaxLength(12, ErrorMessage = "最多12个字符")]
        public string ConfirmPass { get; set; }

        [Required]
        public string RealName { get; set; }

        [Phone]
        public string Mobile { get; set; }
    }
}
