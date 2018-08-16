using DBAgent.Adapter;
using DBAgent.Entity;
using SampleUtils.XMLUtils;
using System.Collections.Generic;
using System.Data;
using TaskAPI.Entity;

namespace CustomAPI.Models
{
    public class CustomAPIManager
    {
        public DataTable DataResult(Dictionary<string, object> dict)
        {
            DBUtil dbUtil = new DBUtil();
            SQLExecuteParam param = new SQLExecuteParam();
            param.dict = dict;
            param.sql = XMLHelper.GetNodeString("CustomAPI", "SQL/" + dict["sql"].ToString());
            return dbUtil.SQLExecuteReturnTable(param);
        }

        public PaginationDataTable PaginationResult(Dictionary<string, object> dict)
        {
            DBUtil dbUtil = new DBUtil();
            SQLExecuteParam param = new SQLExecuteParam();
            param.dict = dict;
            param.sql = XMLHelper.GetNodeString("CustomAPI", "SQL/" + dict["sql"].ToString());
            return dbUtil.SQLExecuteReturnPaginationTable(param);
        }
    }
}