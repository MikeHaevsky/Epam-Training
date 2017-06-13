using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class WatcherLogger
    {
        public bool IsRunConsole
        {
            get;
            set;
        }
        object obj = new object();
        public void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                string logFile = String.Concat(BLHelper.FolderSetting, Resource.LogFileName);
                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    string message = String.Format("{0} file {1} has {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent);
                    writer.WriteLine(message);
                    writer.Flush();
                    if (this.IsRunConsole == true)
                        Console.WriteLine(message);
                }
            }
        }
    }
}
