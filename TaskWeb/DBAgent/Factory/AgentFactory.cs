using DBAgent.Product;

namespace DBAgent.Factory
{
    public class AgentFactory
    {
        public IAgent InitAgent(string type, string connStr) {
            IAgent rst = null;
            switch (type) {
                case "mysql": return rst = new MySQLAgent(connStr);
                case "mssql": return rst = new MSSQLAgent(connStr);
                default:; break;
            }

            return rst;
        }

    }
}
