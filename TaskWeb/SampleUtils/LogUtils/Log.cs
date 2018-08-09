using System;
using System.IO;

namespace SampleUtils.LogUtils
{
    public class LogHelper
    {
        /// <summary>
        /// 写log方法
        /// </summary>
        /// <param name="str">log内容</param>
        public void WriteLog(string str, string filePath, string fileName)
        {
            StreamWriter sw = null;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath += "\\" + fileName;
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
