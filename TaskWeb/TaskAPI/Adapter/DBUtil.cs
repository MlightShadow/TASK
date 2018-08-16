using DBAgent.Entity;
using SampleUtils.LogUtils;
using System;
using System.Data;
using TaskAPI.Entity;

namespace DBAgent.Adapter
{
    internal class DBUtil : LogHelper, IDBAdapter
    {
        DataTable IDBAdapter.SQLExecuteReturnTable()
        {
            throw new NotImplementedException();
        }

        internal DataTable SQLExecuteReturnTable(SQLExecuteParam param)
        {
            throw new NotImplementedException();
        }

        internal PaginationDataTable SQLExecuteReturnPaginationTable(SQLExecuteParam param)
        {
            throw new NotImplementedException();
        }
    }
}
