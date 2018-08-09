using SampleUtils.LogUtils;
using System;

namespace DBAgent.Adapter
{
    internal class LogUtil : LogHelper, ILogAdapter
    {
        void ILogAdapter.WriteLog(string str)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "DBAgentLog\\" + DateTime.Today.Date.ToString("yyyy") + "\\" + DateTime.Today.Date.ToString("MM");
            string fileName = DateTime.Today.Date.ToString("dd") + "Log.txt";
            WriteLog(str, filePath, fileName);
        }
    }
}
