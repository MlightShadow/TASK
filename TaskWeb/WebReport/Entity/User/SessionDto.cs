using System;
using System.Collections.Generic;

namespace WebReport.Entity.User
{
    [Serializable]
    public class SessionDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户别名
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remarks { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int roleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string roleName { get; set; }

        /// <summary>
        /// 删除位
        /// </summary>
        public bool isDeleted { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<PageTreeDto> powerList { get; set; }
    }
}