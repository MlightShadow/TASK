using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public string Post([FromBody]string userName, [FromBody]string password)
        {
            return "its work";
        }
    }
}
