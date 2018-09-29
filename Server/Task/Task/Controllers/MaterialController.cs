using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Task.Entities;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/Material")]
    public class MaterialController : Controller
    {
        // GET: api/Material
        [HttpGet]
        public IEnumerable<MaterialInfo> Get()
        {
            return new List<MaterialInfo>();
        }

        // GET: api/Material/5
        [HttpGet("{id}")]
        public MaterialInfo Get(int id)
        {
            return new MaterialInfo();
        }
        
        // POST: api/Material
        [HttpPost]
        public ResCode Post(MaterialInfo materialInfo)
        {
            return new ResCode();
        }
        
        // PUT: api/Material/5
        [HttpPut("{id}")]
        public ResCode Put(int id, MaterialInfo materialInfo)
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
