
using DBAgent.Entity;
using System.Collections.Generic;
using System.Data;

namespace DBAgent.Product
{
    public interface IAgent
    {
        T SQLExecuteSingleData<T>(SQLExecuteParam dto) where T : new();
        DataTable SQLExecuteReturnTable(SQLExecuteParam dto);
        int SQLExecuteReturnRows(SQLExecuteParam dto);
        List<T> SQLExecuteReturnList<T>(SQLExecuteParam dto) where T : new();
        PaginationResult<T> SQLExecuteReturnPaginationList<T>(SQLExecuteParam dto) where T : new();
        void SQLExecuteProcedure(SQLExecuteParam dto);
    }
}
