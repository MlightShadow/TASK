using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class ProfileController : SessionController
    {
        UserManager userManager = new UserManager();
        /// <summary>
        /// 修改密码画面
        /// </summary>
        /// <returns></returns>
        public ActionResult Password()
        {
            return View();
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public JsonResult SavePassword(string newPassword, string oldPassword)
        {
            if (userManager.ChangePassword(SysSession.name, newPassword, oldPassword)) {
                Session["WebReportUser"] = null;
                return commManager.MakeJsonResult(1, "修改成功, 请重新登录");
            }
            return commManager.MakeJsonResult(-1, "原密码错误, 请重试");
        }
    }
}