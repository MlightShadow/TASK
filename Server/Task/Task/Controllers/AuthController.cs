using Microsoft.AspNetCore.Mvc;
using Task.Entities;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        // GET: api/Auth/
        [HttpGet]
        public UserAuthInfo Get([FromBody]AccountInfo accountInfo)
        {
            return new UserAuthInfo();
        }

    }
}
