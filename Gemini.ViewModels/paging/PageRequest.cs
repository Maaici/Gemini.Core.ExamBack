using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.ViewModels.paging
{
    public class PageRequest
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int limit { get; set; }

        public string key { get; set; }

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public PageRequest()
        {
            page = 1;
            limit = 10;
        }

        /// <summary>
        /// 公共查询参数
        /// </summary>
        public string searchVal { get; set; }
    }
}
