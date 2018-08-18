using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 根据ID获取账户信息, 包括角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Account")]
        public string Get(int id)
        {
            // GET: api/Account/5
            return "value";
        }
        
        /// <summary>
        /// 添加账号
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody]string userName, [FromBody]string password)
        {
            // POST: api/Account
            // TODO 名称校验规则
            // TODO 创建账号
            return "success";
        }
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

            // PUT: api/Account/5
        }
    }
}
