using System.Web.Mvc;
using WebReport.Entity.User;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class LoginController : BaseController
    {
        UserManager userManager = new UserManager();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DoLogin(UserDto user)
        {
            bool powerFlag = false;

            SessionDto sessionDto = new SessionDto();
            sessionDto = userManager.GetUserInfo(user);
            if (sessionDto != null)
            {
                if (powerFlag)
                {
                    //获取权限
                    PowerManager powerManager = new PowerManager();
                    sessionDto.powerList = powerManager.GetPowerList(sessionDto.roleId);
                }
                //Session
                Session["WebReportUser"] = sessionDto;
                return commManager.MakeJsonResult(1, "登录成功");
            }
            else
            {
                return commManager.MakeJsonResult(-1, "登录失败");
            }
        }

        public ActionResult Logout(UserDto user)
        {
            Session["WebReportUser"] = null;
            return View("Index");
        }
    }
}