using SampleUtils.LogUtils;
using System;
using System.Data;

namespace DBAgent.Adapter
{
    internal class DBUtil : LogHelper, IDBAdapter
    {
        DataTable IDBAdapter.SQLExecuteReturnTable()
        {
            throw new NotImplementedException();
        }
    }
}
