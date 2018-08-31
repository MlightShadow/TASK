using System.Collections.Generic;
using WebReport.Entity.Sys;
using WebReport.Entity.User;
using WebReport.Utils;

namespace WebReport.Models
{
    public class RoleManager : BaseManager
    {
        public List<RoleDto> ListRole() {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = "select id, roleName from tbRole ";
            return DBAgent.SQLExecuteReturnList<RoleDto>(param);
        }

        public PaginationResult<RoleDto> ListRolePagination(PaginationInfo pagInfo, string searchString)
        {
            return DBAgent.SQLExecuteReturnPaginationList<RoleDto>(
                InitSQLParam(pagInfo, new { searchString = searchString }, XMLHelper.GetNodeString("Role", "SQL/ListRolePagination")));
        }

        public bool RemoveRole(int id)
        {
            return ModifyDataColumnById("tbRole", "isDeleted", "1", id);
        }

        public bool RestoreRole(int id)
        {
            return ModifyDataColumnById("tbRole", "isDeleted", "0", id);
        }

        public int SaveRole(RoleDto role)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = role;

            if (role.id == 0)
            {
                //新增
                param.sql = "INSERT INTO tbRole (roleName, remarks) VALUES (@roleName, @remarks)";
            }
            else
            {
                //更新
                param.sql = "update tbRole set roleName=@roleName, remarks=@remarks where id=@id";
            }

            return DBAgent.SQLExecuteReturnRows(param);
        }


    }
}