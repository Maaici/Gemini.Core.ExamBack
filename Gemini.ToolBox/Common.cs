using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Gemini.ToolBox
{
    public static class Common
    {
        #region 转换数字
        public static float GetNum(object o)
        {
            if (o == null)
            {
                return 0;
            }
            else
            {
                float outNum = 0;
                float.TryParse(o.ToString(), out outNum);
                return outNum;
            }
        }

        public static int GetNumInt(object o)
        {
            if (o == null)
            {
                return 0;
            }
            else
            {
                int outNum = 0;
                int.TryParse(o.ToString(), out outNum);
                return outNum;
            }
        }
        #endregion

        #region 时间戳转换
        /// <summary>
        /// 日期转换成unix时间戳（毫秒）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalMilliseconds);
        }

        /// <summary>
        /// unix时间戳转换成日期
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（毫秒）</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddMilliseconds(timestamp);
        }
        #endregion

        #region MD5加密
        public static string ConvertToMD5(string str)
        {
            MD5 md = MD5.Create();
            byte[] mydata = md.ComputeHash(Encoding.UTF8.GetBytes(str));
            string newpwd = "";
            foreach (byte tmp in mydata)
            {
                newpwd += tmp.ToString("x2");
            }
            return newpwd.ToUpper();
        }
        #endregion

        #region 短信

        /// <summary>
        /// 获取用于短信验证的纯数字验证码
        /// </summary>
        /// <param name="codeLength">指定验证码的长度</param>
        /// <returns></returns>
        public static string GetValidateCode(int codeLength)
        {
            String sResultCode = String.Empty;
            char[] oCharacter = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random oRnd = new Random();
            //生成驗證碼字串
            for (int i = 1; i <= codeLength; i++)
            {
                sResultCode += oCharacter[oRnd.Next(oCharacter.Length)];
            }

            return sResultCode;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <param name="smsContent">短信内容</param>
        /// <returns></returns>
        public static string SendSMS(string mobile, string smsContent)
        {
            string result = "";
            if (!string.IsNullOrEmpty(mobile))
            {
                string strSmsParam = "name=kshrExam&t=Busi_1&c=ABCD&mobile=" + mobile + "&txt=" + smsContent + "&time=&extno=";
                result = HttpHelper.HttpPost("http://192.168.44.16:802/KSHRSms.aspx", strSmsParam);
            }
            return result;
        }
        #endregion
    }
}
