using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.Redis
{
    public static class RedisHelper
    {
        public static RedisOperator Default { get { return new RedisOperator(""); } }
    }
}
