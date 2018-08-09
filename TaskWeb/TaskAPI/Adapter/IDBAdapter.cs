using System.Data;

namespace DBAgent.Adapter
{
    interface IDBAdapter
    {
        DataTable SQLExecuteReturnTable();
    }
}
