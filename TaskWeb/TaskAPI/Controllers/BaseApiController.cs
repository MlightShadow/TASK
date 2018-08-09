using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace CustomAPI.Controllers
{
    public class BaseApiController : Controller
    {
        /// <summary>
        /// 从URL获取参数
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="requestMessage"></param>
        public void GetUrlParams(Dictionary<string, object> dict, HttpRequestMessage requestMessage)
        {
            string query = requestMessage.RequestUri.Query;
            if (query != null && query != "") {
                string[] param = query.Replace("?", "").Split('&');
                foreach (var item in param)
                {
                    string[] kv = item.Split('=');
                    dict.Add(HttpUtility.UrlDecode(kv[0], Encoding.UTF8), HttpUtility.UrlDecode(kv[1], Encoding.UTF8));
                }
            }
        }

        /// <summary>
        /// 从FormBody获取参数
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="obj"></param>
        public void GetFormParam(Dictionary<string, object> dict, JObject obj) {
            foreach (var item in obj)
            {
                dict.Add(item.Key.ToString(), item.Value.ToString());
            }
        }
    }
}
