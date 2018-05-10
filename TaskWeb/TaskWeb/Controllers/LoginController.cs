using TaskWeb.Models;
using TaskWeb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskWeb.Manager;

namespace TaskWeb.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login(string username, string password)
        {
            UserDto user = userManager.Login(username, password);
            if (user != null)
            {
                //  登录成功
                Session["TaskWebSession"] = user;
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewBag.ErrorMsg = "请检查帐号密码(帐号或密码错误)";
            }

            return Index();
        }
        
    }
}
