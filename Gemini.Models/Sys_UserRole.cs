using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gemini.Models
{
    public class Sys_UserRole
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Sys_User User { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Sys_Role Role { get; set; }
    }
}
