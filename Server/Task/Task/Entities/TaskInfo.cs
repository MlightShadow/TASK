using System.Collections.Generic;

namespace Task.Entities
{
    /// <summary>
    /// 任务信息
    /// </summary>
    public class TaskInfo : BaseInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string beginDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; }

        /// <summary>
        /// 材料(客人信息)列表
        /// </summary>
        public List<MaterialInfo> materialList { get; set; }

        /// <summary>
        /// 人员列表
        /// </summary>
        public List<UserInfo> userList { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<AttachInfo> attachList { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remarks { get; set; }
    }
}
