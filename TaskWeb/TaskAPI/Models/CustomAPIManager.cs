using System.Collections.Generic;
using System.Data;

namespace CustomAPI.Models
{
    public class CustomAPIManager
    {
        public DataTable DataResult(Dictionary<string, object> dict)
        {
            CommDAL DBAgent = new CommDAL();
            SQLExecuteParam param = new SQLExecuteParam();
            param.dict = dict;
            param.sql = XMLHelper.GetNodeString("CustomAPI", "SQL/" + dict["sql"].ToString());
            return DBAgent.SQLExecuteReturnTable(param);
        }

        public PaginationDataTable PaginationResult(Dictionary<string, object> dict)
        {
            CommDAL DBAgent = new CommDAL();
            SQLExecuteParam param = new SQLExecuteParam();
            param.dict = dict;
            param.sql = XMLHelper.GetNodeString("CustomAPI", "SQL/" + dict["sql"].ToString());
            return DBAgent.SQLExecuteReturnPaginationTable(param);
        }
    }
}