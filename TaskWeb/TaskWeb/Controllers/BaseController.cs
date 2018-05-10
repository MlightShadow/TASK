using TaskWeb.Models;
using TaskWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskWeb.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult jsonResult = new JsonResult();
        protected DapperCommDAL DBAgent = null;
        /// <summary>
        /// 后台session
        /// </summary>
        protected UserDto TaskWebSession = null;

        /// <summary>
        /// Session登陆判断
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session["TaskWebSession"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Index");
            }
            else
            {
                TaskWebSession = Session["TaskWebSession"] as UserDto;
            }
        }

        /// <summary>
        /// Session登陆判断
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if(TaskWebSession != null){
                ViewBag.username = TaskWebSession.user_name;
                ViewBag.nick_name = TaskWebSession.nick_name;
            }
        }
        
        /// <summary> 
        /// 获取时间戳 
        /// </summary> 
        /// <returns></returns> 
        public static string GetTimeStampByMilliseconds()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        } 
    }
}
