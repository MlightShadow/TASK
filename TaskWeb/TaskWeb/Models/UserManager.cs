using System.Collections.Generic;
using TaskWeb.Entitys;
using TaskWeb.Utils;

namespace TaskWeb.Models
{
    public class UserManager : BaseManager
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDto Login(string username, string password)
        {
            UserDto user = null;
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = new
            {
                username = username,
                password = password
            };
            param.sql = "select * from tb_user where user_name = @username and `password` = MD5(@password)";
            user = DBAgent.SQLExecuteSingleData<UserDto>(param);

            return user;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Register(string username, string password)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = new
            {
                username = username,
                password = password
            };
            param.sql = @"INSERT INTO tb_user (user_name, `password`)
                        VALUES
	                        (@username, MD5(@PASSWORD))";
            if (DBAgent.SQLExecuteReturnRows(param) == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否存在该用户名
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true 存在 false 不存在</returns>
        public bool CheckUserNameExist(string username)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = new
            {
                username = username
            };
            param.sql = "select * from tb_user where user_name = @username";
            if (DBAgent.SQLExecuteSingleData<UserDto>(param) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改用户昵称
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyUserInfo(UserDto user) {
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = user;
            param.sql = "update tb_user set nick_name = @nick_name where id = @id ";
            if (DBAgent.SQLExecuteReturnRows(param) == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<UserDto> GetUserList()
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = @"
                        select * from tb_user order by id desc
                        ";
            return DBAgent.SQLExecuteReturnList<UserDto>(param);
        }

    }
}