
using System.Web.Mvc;
using WebReport.Entity.Sys;
using WebReport.Entity.User;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class UserController : SessionController
    {
        UserManager userManager = new UserManager();
        RoleManager roleManager = new RoleManager();

        /// <summary>
        /// 后台用户管理首页
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            ViewBag.RoleList = roleManager.ListRole(); ;
            return View();
        }

        /// <summary>
        /// 添加用户账号
        /// </summary>
        /// <param name="user">用户Model</param>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult SaveUser(UserDto user)
        {
            if (userManager.SaveUser(user) == 1)
            {
                return commManager.MakeJsonResult(1, "添加成功");
            }
            return commManager.MakeJsonResult(-1, "操作失败");
        }

        /// <summary>
        /// 判断账号名是否存在
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult CheckUserExistByName(string name)
        {
            if (userManager.CheckUserExistByName(name))
            {
                return commManager.MakeJsonResult(1, "该账号已存在");
            }
            return commManager.MakeJsonResult(-1, "账户可以使用");
        }

        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <param name="query">jqgrid分页信息</param>
        /// <returns>JsonResult</returns>
        public JsonResult ListUserPagination(PaginationInfo pagInfo, string searchString)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = userManager.ListUserPagination(pagInfo, searchString);
            return jsonResult;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ResetPassword(int id)
        {
            if (userManager.ResetPassword(id))
            {
                return commManager.MakeJsonResult(1, "重置完成, 当前密码: 888888");
            }
            return commManager.MakeJsonResult(-1, "重置失败");
        }

        /// <summary>
        /// 冻结账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult RemoveUser(int id)
        {
            if (userManager.RemoveUser(id))
            {
                return commManager.MakeJsonResult(1, "冻结成功");
            }
            return commManager.MakeJsonResult(-1, "冻结失败");
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult RestoreUser(int id)
        {
            if (userManager.RestoreUser(id))
            {
                return commManager.MakeJsonResult(1, "恢复成功");
            }
            return commManager.MakeJsonResult(-1, "恢复失败");
        }
    }
}