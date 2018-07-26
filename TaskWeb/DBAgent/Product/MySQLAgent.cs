using System.Collections.Generic;
using System.Data;
using DBAgent.Entity;
using MySql.Data.MySqlClient;

namespace DBAgent.Product
{
    internal class MySQLAgent : BaseAgent, IAgent
    {
        public MySQLAgent(string connStr) {
            InitAgent(connStr);
            connection = new MySqlConnection(this.connStr);
        }

        void IAgent.SQLExecuteProcedure(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }

        List<T> IAgent.SQLExecuteReturnList<T>(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }

        PaginationResult<T> IAgent.SQLExecuteReturnPaginationList<T>(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }

        int IAgent.SQLExecuteReturnRows(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }

        DataTable IAgent.SQLExecuteReturnTable(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }

        T IAgent.SQLExecuteSingleData<T>(SQLExecuteParam dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
