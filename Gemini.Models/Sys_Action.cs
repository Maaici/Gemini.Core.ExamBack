using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gemini.Models
{
    public class Sys_Action
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public string ActionName { get; set; }

        public string Description { get; set; }

        public int Enabled { get; set; }

        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        [ForeignKey("MenuId")]
        public Sys_Menu Menu { get; set; }
    }
}
