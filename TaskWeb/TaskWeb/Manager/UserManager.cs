using TaskWeb.Models;
using TaskWeb.Utils;

namespace TaskWeb.Manager
{
    public class UserManager : BaseManager
    {
        public UserDto Login(string username, string password) {

            UserDto user = null;
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = new {
                username= username,
                password= password
            };
            param.sql = "select * from tb_user where user_name = @username and `password` = @password";
            user = DBAgent.SQLExecuteSingleData<UserDto>(param);

           return user;
        }

    }
}