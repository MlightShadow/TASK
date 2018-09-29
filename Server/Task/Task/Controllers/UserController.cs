using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Task.Entities;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            return new List<UserInfo>();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserInfo Get(int id)
        {
            return new UserInfo();
        }
        
        // POST: api/User
        [HttpPost]
        public ResCode Post(UserInfo userInfo)
        {
            return new ResCode();
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public ResCode Put(int id, UserInfo userInfo)
        {
            return new ResCode();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ResCode Delete(int id)
        {
            return new ResCode();
        }
    }
}
