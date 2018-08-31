
using Dapper;
using System;
using System.Collections.Generic;

namespace WebReport.Entity.Sys
{
    /// <summary>
    /// 执行sql的参数及sql文组合传值到Dapper执行 参数执行顺序为实体类obj > dict obj为null, dict.count = 0 视为无参
    /// </summary>
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