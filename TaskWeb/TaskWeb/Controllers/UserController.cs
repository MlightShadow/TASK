using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskWeb.Manager;

namespace TaskWeb.Controllers
{
    public class UserController : BaseController
    {
        UserManager userManager = new UserManager();
        ResultManager resultManager = new ResultManager();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ModifyInfo(string  nickname) {
            TaskWebSession.nick_name = nickname;
            if (userManager.ModifyUserInfo(TaskWebSession)) {
                //刷新session
                Session["TaskWebSession"] = TaskWebSession;
                return resultManager.SuccessResult();
            }
            return resultManager.FailureResult();
        }

    }
}
