using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gemini.ViewModels
{
    public class AccountViewModel
    {
        public string Name { get; set; }

        public string IdcardNumber { get; set; }

        [RegularExpression("^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\\d{8}$",ErrorMessage ="手机号码格式不正确")]
        public string Mobile { get; set; }

        public string Password { get; set; }

        public string RegMsgCode { get; set; }
    }
}
