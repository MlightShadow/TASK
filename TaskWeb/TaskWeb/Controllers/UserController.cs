using System.Web.Mvc;
using TaskWeb.Models;

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

        public ActionResult List()
        {
            return View();
        }
        
        public JsonResult GetUserList()
        {
            jsonResult.Data = userManager.GetUserList();
            return jsonResult;
        }

        public JsonResult ModifyInfo(string  nickname, string bio, string pic) {
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
