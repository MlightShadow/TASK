using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomAPI.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using DBAgent.Entity;

namespace CustomAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomController : BaseApiController
    {
        CustomAPIManager customApiManager = new CustomAPIManager();

        [HttpPost]
        public JsonResult Custom([FromBody]JObject obj, HttpRequestMessage requestMessage)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            GetFormParam(dict, obj);
            return Json(customApiManager.DataResult(dict));
        }
        
        [HttpPost]
        public JsonResult ListPagination([FromBody]JObject obj, HttpRequestMessage requestMessage) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            GetFormParam(dict, obj);

            PaginationInfo paginationInfo = new PaginationInfo();
            paginationInfo.limit = Convert.ToInt32(dict["limit"]);
            paginationInfo.offset = Convert.ToInt32(dict["offset"]);

            return Json(customApiManager.PaginationResult(dict));
        }
    }
}
