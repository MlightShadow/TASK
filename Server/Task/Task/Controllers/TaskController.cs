using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Task.Entities;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        // GET: api/Task
        [HttpGet]
        public IEnumerable<TaskInfo> Get()
        {
            int i = 0;
            List<TaskInfo> list = new List<TaskInfo>();
            while (i < 5)
            {
                i++;
                TaskInfo task = new TaskInfo();
                list.Add(task);
            }

            return list;
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public TaskInfo Get(int id)
        {
            return new TaskInfo();
        }
        
        // POST: api/Task
        [HttpPost]
        public ResCode Post(TaskInfo taskInfo)
        {
            ResCode res = new ResCode();
            res.obj = taskInfo;
            return res;
        }
        
        // PUT: api/Task/5
        [HttpPut("{id}")]
        public ResCode Put(int id, TaskInfo taskInfo)
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
