using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebReport.Entity.Sys
{
    public class MultiSQLExecuteParam
    {

        /// <summary>
        /// 主体执行前执行sql
        /// </summary>
        public string beforeSql { get; set; }
        public Dictionary<string, object> beforeParam = new Dictionary<string, object>();
        public object beforeObj = null;

        /// <summary>
        /// 主体执行完成执行sql
        /// </summary>
        public string afterSql { get; set; }
        public Dictionary<string, object> afterParam = new Dictionary<string, object>();
        public object afterObj = null;

        public string listSql { get; set; }
        /// <summary>
        /// 执行对象list
        /// </summary>
        public List<Object> objList = new List<Object>();
    }
}