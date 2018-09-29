using System.Collections.Generic;

namespace Task.Entities
{
    /// <summary>
    /// 客户材料
    /// </summary>
    public class MaterialInfo : BaseInfo
    {
        /// <summary>
        /// 客户名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string age { get; set; }
        
        /// <summary>
        /// 备注 
        /// </summary>
        public string remarks { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public AddressInfo address { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<AttachInfo> attachList { get; set; }

    }
}
