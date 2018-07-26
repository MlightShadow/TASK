
using Dapper;
using System;
using System.Collections.Generic;

namespace DBAgent.Entity
{
    public class SQLExecuteParam
    {
        /// <summary>
        /// 实体参数
        /// </summary>
        public Object obj = null;

        /// <summary>
        /// 参数
        /// </summary>
        public Dictionary<string, object> dict = new Dictionary<string, object>();

        /// <summary>
        /// sql文
        /// </summary>
        public string sql { get; set; }

        public DynamicParameters procedureParam = new DynamicParameters();

        /// <summary>
        /// 分页信息
        /// </summary>
        public PaginationInfo pagination = null;
    }
}
