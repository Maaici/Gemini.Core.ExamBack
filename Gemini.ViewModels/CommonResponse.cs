using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.ViewModels
{
    public class CommonResponse
    {
        public bool Success { get; set; }

        public string RetMsg { get; set; }

        public dynamic Data { get; set; }
    }
}
