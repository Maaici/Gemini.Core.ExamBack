using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gemini.Models
{
    public class Sys_RoleMenu
    {

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Sys_Role Role { get; set; }


        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Sys_Menu Menu { get; set; }
    }
}
