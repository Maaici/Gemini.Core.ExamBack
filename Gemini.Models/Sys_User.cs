using System;
using System.Collections.Generic;

namespace Gemini.Models
{
    public class Sys_User
    {
        public Sys_User()
        {
            UserRoles = new List<Sys_UserRole>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string RealName { get; set; }

        /// <summary>
        /// 1表示启用，0或其他表示停用
        /// </summary>
        public int Enabled { get; set; }

        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreateUser { get; set; }

        public DateTime? EditTime { get; set; }

        public string EditUser { get; set; }

        public List<Sys_UserRole> UserRoles { get; set; }
    }
}
