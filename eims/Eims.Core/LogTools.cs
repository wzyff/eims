using System;
using System.IO;
using System.Text;

namespace Eims.Core
{
    /// <summary>
    /// 写入一个异常错误
    /// </summary>
    /// <param name="ex">异常</param>
    public static class LogTools
    {
        /// <summary>
        /// 加入异常日志
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteException(string ex)
        {
            string subFold = DateTime.Now.Year + DateTime.Now.Month.ToString("D2");
            string fileName = subFold + DateTime.Now.Day.ToString("D2") + ".txt";
            string path = "C:/LogFile/" + subFold;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string wholePath = path + "\\" + fileName;
            using (StreamWriter sw = new StreamWriter(wholePath, true, Encoding.UTF8))
            {
                sw.WriteLine(ex);
                sw.Dispose();
                sw.Close();
            }
            return;
        }
    }
}
