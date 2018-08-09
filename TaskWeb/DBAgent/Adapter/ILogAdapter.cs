namespace DBAgent.Adapter
{
    interface ILogAdapter : IAdapter
    {
        void WriteLog(string str);
    }
}
