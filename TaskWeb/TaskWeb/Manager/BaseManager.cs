using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWeb.Utils;

namespace TaskWeb.Manager
{
    public class BaseManager
    {
         protected DapperCommDAL DBAgent = new DapperCommDAL();
    }
}