using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWeb.Utils;

namespace TaskWeb.Models
{
    public class BaseManager
    {
         protected DapperCommDAL DBAgent = new DapperCommDAL();
    }
}