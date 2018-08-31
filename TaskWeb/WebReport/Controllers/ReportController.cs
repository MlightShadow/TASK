using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebReport.Entity.Report;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class ReportController : SessionController
    {
        ReportManager reportManager = new ReportManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Custom(string PageName)
        {
            return View(PageName);
        }

        public JsonResult ListSalary(DateTime? queryDate)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = reportManager.ListSalary();
            return jsonResult;
        }

        public JsonResult ListCustomReport(FormCollection fc)
        {
            JsonResult jsonResult = new JsonResult();
            Dictionary<string, object> dict = GetRequestParam(fc);
            dict.Add("yh", SysSession.name);

            jsonResult.Data = JsonConvert.SerializeObject(reportManager.ListIndex_Custom(dict));

            return jsonResult;
        }

        /// <summary>
        /// 动态获取传参
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        protected Dictionary<string, object> GetRequestParam(FormCollection fc)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (string key in fc)
            {
                dict.Add(key, fc[key]);
            }
            return dict;
        }

    }
}