using WebReport.Entity.Page;

namespace WebReport.Entity.User
{
    public class PagePowerDto : PageDto
    {
        /// <summary>
        /// 判断是否拥有权限
        /// </summary>
        public int powerId { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public string text { get; set; }
    }
}