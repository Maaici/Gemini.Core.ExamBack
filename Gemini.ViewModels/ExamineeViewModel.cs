using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gemini.ViewModels
{
    public class ExamineeViewModel
    {
        public int Id { get; set; }

        [Phone(ErrorMessage ="请输入正确的电话号码！")]
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string IdcardNumber { get; set; }
        public DateTime InTime { get; set; }
    }
}
