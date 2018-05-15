using TaskWeb.Models;
using System.Web.Mvc;
using TaskWeb.Manager;

namespace TaskWeb.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();
        ResultManager resultManager = new ResultManager();
        JsonResult jsonResult = new JsonResult();

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult Login(string username, string password)
        {
            UserDto user = userManager.Login(username, password);
            if (user != null)
            {
                //登录成功
                Session["TaskWebSession"] = user;
                return resultManager.SuccessResult();
            }
            return resultManager.FailureResult();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult DoRegister(string username, string password)
        {
            if (!userManager.CheckUserNameExist(username))
            {
                //不存在用户名重复 直接注册
                return userManager.Register(username, password) ? resultManager.SuccessResult() : resultManager.FailureResult();
            }
            return resultManager.FailureResult();
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public JsonResult CheckUserNameExist(string username)
        {
            return userManager.CheckUserNameExist(username) ? resultManager.FailureResult() : resultManager.SuccessResult();
        }
    }
}
