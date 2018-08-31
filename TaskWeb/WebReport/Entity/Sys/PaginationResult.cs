using System.Collections.Generic;

namespace WebReport.Entity.Sys
{
    /// <summary>
    /// 分页返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationResult<T> : PaginationInfo
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int page { get { return (this.total / this.limit) + this.total % this.limit != 0 ? 1 : 0; } }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total { set; get; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> rows = null;
    }
}