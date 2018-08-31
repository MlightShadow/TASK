
using System.Web.Mvc;
using WebReport.Entity.User;
using WebReport.Utils;

namespace WebReport.Controllers
{
    public class SessionController : BaseController
    {
        /// <summary>
        /// 后台session
        /// </summary>
        protected SessionDto SysSession = null;

        /// <summary>
        /// 后台系统Session登陆判断
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session["WebReportUser"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Index");
            }
            else
            {
                SysSession = Session["WebReportUser"] as SessionDto;
                if (SysSession.password == XMLHelper.GetNodeString("User", "SQL/MustChangePassword")) {
                    filterContext.HttpContext.Response.Redirect("~/Profile/Password");
                }
            }
        }

        /// <summary>
        /// Session登陆判断
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (SysSession != null)
            {
                ViewBag.SysSession = SysSession;
            }
            else
            {
                ViewBag.SysSession = null;
            }
        }
    }
}