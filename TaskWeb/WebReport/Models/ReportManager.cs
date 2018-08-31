using System;
using System.Collections.Generic;
using System.Data;
using WebReport.Entity.Report;
using WebReport.Entity.Sys;
using WebReport.Utils;

namespace WebReport.Models
{
    public class ReportManager : BaseManager
    {
        public List<SalaryDto> ListSalary()
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = XMLHelper.GetNodeString("Report", "SQL/ListSalary");
            return DBAgent.SQLExecuteReturnList<SalaryDto>(param);
        }

        public DataTable ListIndex_Custom(Dictionary<string, object> dict)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.dict = dict;
            param.sql = XMLHelper.GetNodeString("Report", "SQL/" + dict["sql"].ToString());
            return DBAgent.SQLExecuteReturnTable(param);
        }
    }
}