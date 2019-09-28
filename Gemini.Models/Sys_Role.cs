using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.Models
{
    public class Sys_Role
    {
        public Sys_Role()
        {
            userRoles = new List<Sys_UserRole>();
            RoleMenus = new List<Sys_RoleMenu>();
        }
        public int Id { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public int Enabled { get; set; }

        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public List<Sys_UserRole> userRoles { get; set; }

        public List<Sys_RoleMenu> RoleMenus { get; set; }
    }
}
