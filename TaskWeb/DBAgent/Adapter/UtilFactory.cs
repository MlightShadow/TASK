namespace DBAgent.Adapter
{
    internal class UtilFactory
    {
        public ILogAdapter GetLogUtil() {
            return new LogUtil();
        }
    }
}
