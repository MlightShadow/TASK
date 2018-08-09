namespace DBAgent.Adapter
{
    internal class UtilFactory
    {
        public IDBAdapter GetDBUtil() {
            return new DBUtil();
        }
    }
}
