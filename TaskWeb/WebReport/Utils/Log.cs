using System;
using System.IO;

namespace WebReport.Utils
{
    public static class Log
    {
        /// <summary>
        /// 写log方法
        /// </summary>
        /// <param name="str">log内容</param>
        public static void WriteLog(string str)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Today.Date.ToString("yyyy") + "\\" + DateTime.Today.Date.ToString("MM");
            StreamWriter sw = null;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath += "\\" + DateTime.Today.Date.ToString("dd") + "Log.txt";
            if (!File.Exists(filePath))
            {
                sw = File.CreateText(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.Write(DateTime.Now.ToString() + " " + str + Environment.NewLine);
            sw.Close();
        }
    }
}