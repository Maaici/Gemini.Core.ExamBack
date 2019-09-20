using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Gemini.ToolBox
{
    /// <summary>
    /// 执行http请求
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        /// Get Http
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="param">传递的参数,格式"a=1&b=2"</param>
        public static string HttpGet(string url, string param)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            string responseContent = null;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "?" + param);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = 20000;

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                responseContent = streamReader.ReadToEnd();
            }
            catch { }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
                if (httpWebRequest != null)
                    httpWebRequest.Abort();
                if (httpWebResponse != null)
                    httpWebResponse.Close();
            }
            return responseContent;
        }

        /// <summary>
        /// Post Http
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="data">传递的参数,格式"a=1&b=2"</param>
        public static string HttpPost(string url, string data)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000;

                byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(data);
                httpWebRequest.ContentLength = postBytes.Length;
                httpWebRequest.Proxy = null;

                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(postBytes, 0, postBytes.Length);
                    stream.Close();
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (httpWebRequest != null)
                    httpWebRequest.Abort();
                if (httpWebResponse != null)
                    httpWebResponse.Close();
            }
        }
    }
}
