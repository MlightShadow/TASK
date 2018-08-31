
using System.Web.Mvc;
using WebReport.Entity.Sys;

namespace WebReport.Models
{
    public class CommManager
    {

        public JsonResult MakeJsonResult(int code, string msg)
        {
            JsonResult jsonResult = new JsonResult();
            JRes jRes = new JRes();
            jRes.msg = msg;
            jRes.res = code;
            jsonResult.Data = jRes;
            return jsonResult;
        }
    }
}