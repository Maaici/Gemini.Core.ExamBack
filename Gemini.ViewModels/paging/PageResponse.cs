using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.ViewModels.paging
{
    public class PageResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public bool Success;
        /// <summary>
        /// 操作消息
        /// </summary>
        public string RetMsg;

        /// <summary>
        /// 总记录条数
        /// </summary>
        public int Count;

        /// <summary>
        /// 数据内容
        /// </summary>
        public dynamic Data;
    }
}
