using System;

namespace Gemini.Models
{
    public class Sys_User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string RealName { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditTime { get; set; }
        public string EditUser { get; set; }
    }
}
