using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebReport.Entity.Sys;
using WebReport.Entity.User;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class RoleController : SessionController
    {
        RoleManager roleManager = new RoleManager();
        PowerManager powerManager = new PowerManager();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public JsonResult ListRolePagination(PaginationInfo pagInfo, string searchString)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = roleManager.ListRolePagination(pagInfo, searchString);
            return jsonResult;
        }

        public JsonResult RemoveRole(int id)
        {
            if (roleManager.RemoveRole(id))
            {
                return commManager.MakeJsonResult(1, "禁用成功");
            }
            return commManager.MakeJsonResult(-1, "禁用失败");
        }

        public JsonResult RestoreRole(int id)
        {
            if (roleManager.RestoreRole(id))
            {
                return commManager.MakeJsonResult(1, "恢复成功");
            }
            return commManager.MakeJsonResult(-1, "恢复失败");
        }
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="dto">前台传进的角色信息</param>
        /// <returns>JsonResult 1 成功 -1 失败</returns>
        public JsonResult SaveRole(RoleDto role)
        {
            if (roleManager.SaveRole(role) == 1)
            {
                return commManager.MakeJsonResult(1, "添加角色成功");
            }
            return commManager.MakeJsonResult(-1, "操作失败");
        }

        /// <summary>
        /// 获取相关角色的权限列表
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        public JsonResult TreePower(int id)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = powerManager.GetPowerList(id);
            return jsonResult;
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="list">权限允许的pagelist</param>
        /// <returns></returns>
        public JsonResult SavePower(int id, string list)
        {
            if (powerManager.SavePower(id, list, SysSession.id))
            {
                return commManager.MakeJsonResult(1, "权限设置成功");
            }
            return commManager.MakeJsonResult(-1, "操作失败");
        }
    }
}