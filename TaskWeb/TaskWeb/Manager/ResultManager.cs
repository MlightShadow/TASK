using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskWeb.Manager
{
    public class ResultManager
    {
        /// <summary>
        /// ajax返回list
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public JsonResult ListResult<T>(List<T> list)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = list;
            return jsonResult;
        }
        
        /// <summary>
        /// ajax操作成功返回消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public JsonResult SuccessResult(string msg = "")
        {
            return JresMaker(1, msg);
        }

        /// <summary>
        /// ajax失败返回消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public JsonResult FailureResult(string msg = "")
        {
            return JresMaker(-1, msg);
        }

        private JsonResult JresMaker(int res, string msg)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = new { res = res, msg = msg };
            return jsonResult;
        }
    }
}