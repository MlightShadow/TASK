
using System.Configuration;
using System.Data;
using WebReport.Entity.Sys;
using WebReport.Entity.User;
using WebReport.Utils;

namespace WebReport.Models
{
    public class UserManager : BaseManager
    {
        public SessionDto GetUserInfo(UserDto user)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = XMLHelper.GetNodeString("User", "SQL/GetUserInfo");


            CommDAL DBAgent = new CommDAL(ConfigurationManager.ConnectionStrings["DALconnect2"].ConnectionString);
            param.procedureParam.Add("@yh", user.name, DbType.String, direction: ParameterDirection.Input);
            param.procedureParam.Add("@mm", user.password, DbType.String, direction: ParameterDirection.Input);
            param.procedureParam.Add("@f", 0, DbType.Int32, direction: ParameterDirection.Output);
            param.procedureParam.Add("@result", "", DbType.String, direction: ParameterDirection.Output);

            DBAgent.SQLExecuteProcedure(param);
            int f = param.procedureParam.Get<int>("@f");
            string result = param.procedureParam.Get<string>("@result");
            
            if (f == 1) {
                SessionDto sessionDto = new SessionDto();
                sessionDto.name = user.name;
                sessionDto.password = user.password;
                return sessionDto;
            }
            return null;

            //user.password = MD5Helper.MD5Encrypt(user.password);
            //param.obj = user;
            //return DBAgent.SQLExecuteSingleData<SessionDto>(param);
        }

        public int SaveUser(UserDto user)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            user.password = MD5Helper.MD5Encrypt(user.password);
            param.obj = user;

            if (user.id == 0)
            {
                //新增
                param.sql = "insert into tbUser (name,nickName,password,roleId) values (@name,@nickName,@password,@roleId)";
            }
            else
            {
                //更新
                param.sql = "update tbUser set name=@name,nickName=@nickName,password=@password,roleId=@roleId where id=@id";
            }

            return DBAgent.SQLExecuteReturnRows(param);
        }

        public bool CheckUserExistByName(string name)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = "select count(*) from tbUser where name=@name";
            param.dict.Add("name", name);
            if (DBAgent.SQLExecuteSingleData<int>(param) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public PaginationResult<UserDto> ListUserPagination(PaginationInfo pagInfo, string searchString)
        {
            return DBAgent.SQLExecuteReturnPaginationList<UserDto>(
                InitSQLParam(pagInfo, new { searchString = searchString }, XMLHelper.GetNodeString("User", "SQL/ListUserPagination")));
        }

        public bool ResetPassword(int id) {
            return ModifyDataColumnById("tbUser", "password", MD5Helper.MD5Encrypt("888888"), id);
        }

        public bool RemoveUser(int id)
        {
            return ModifyDataColumnById("tbUser", "isDeleted", "1", id);
        }

        public bool RestoreUser(int id)
        {
            return ModifyDataColumnById("tbUser", "isDeleted", "0", id);
        }


        /*
        public bool ChangePassword(int id, string newPassword, string oldPassword) {
            SQLExecuteParam param = new SQLExecuteParam();

            //检查老密码是否正确
            param.sql = @"SELECT
	                        *
                        FROM tbUser
                        WHERE id
                        = @id AND password = @password";

            param.dict.Add("id", id);
            param.dict.Add("password", MD5Helper.MD5Encrypt(oldPassword));

            if (DBAgent.SQLExecuteReturnList<UserDto>(param).Count == 1)
            {
                //设置新密码
                param = new SQLExecuteParam();

                param.sql = @"UPDATE tbUser
                            SET password = @password
                            WHERE id
                            = @id";

                param.dict.Add("id", id);
                param.dict.Add("password", MD5Helper.MD5Encrypt(newPassword));

                if (DBAgent.SQLExecuteReturnRows(param) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //*/

        public bool ChangePassword(string name, string newPassword, string oldPassword)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            CommDAL DBAgent = new CommDAL(ConfigurationManager.ConnectionStrings["DALconnect2"].ConnectionString);
            param.procedureParam.Add("@yh", name, DbType.String, direction: ParameterDirection.Input);
            param.procedureParam.Add("@ymm", oldPassword, DbType.String, direction: ParameterDirection.Input);
            param.procedureParam.Add("@xmm", newPassword, DbType.String, direction: ParameterDirection.Input);
            param.procedureParam.Add("@f", 0, DbType.Int32, direction: ParameterDirection.Output);
            param.procedureParam.Add("@result", "", DbType.String, direction: ParameterDirection.Output);
            param.sql = "lc0089999.KHCX_MMXG";
            DBAgent.SQLExecuteProcedure(param);
            int f = param.procedureParam.Get<int>("@f");
            string result = param.procedureParam.Get<string>("@result");
            if (f == 1)
            {
                return true;
            }
            return false;
        }

    }
}