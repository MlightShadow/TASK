
namespace WebReport.Entity.Sys
{
    public class PaginationInfo
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        public int limit { set; get; }

        /// <summary>
        /// 页数
        /// </summary>
        public int offset { set; get; }
    }
}