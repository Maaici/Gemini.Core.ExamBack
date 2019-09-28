using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.Models
{
    public class Sys_Menu
    {
        public Sys_Menu()
        {
            RoleMenus = new List<Sys_RoleMenu>();
            Actions = new List<Sys_Action>();
        }

        public int Id { get; set; }

        public string MenuName { get; set; }

        public string MenuIndex { get; set; }

        public string MenuUrl { get; set; }

        public string ParentId { get; set; }

        public string Description { get; set; }

        public string ICON { get; set; }

        public int Enabled { get; set; }

        public int SortCode { get; set; }

        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public List<Sys_RoleMenu> RoleMenus { get; set; }

        public List<Sys_Action> Actions { get; set; }
    }
}
