using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class ProcessingLogger
    {
        private bool IsRunConsole
        {
            get;
            set;
        }
        private string ProcessingLogFileName
        {
            get;
            set;
        }
        public ProcessingLogger(string fileName, bool isRunConsole)
        {
            IsRunConsole = isRunConsole;
            string processingLogFolder = String.Concat(BLHelper.FolderSetting, Resource.LogProcessingFolder);
            string[] str = fileName.Split('\\');
            int i = str.Count();
            string fileLogName=str[i-1];
            ProcessingLogFileName = string.Concat(processingLogFolder, "\\", fileLogName);
            if (!Directory.Exists(processingLogFolder))
            {
                Directory.CreateDirectory(processingLogFolder);
            }
        }
        public void WriteProcessingMessage(string message)
        {
            try
            {
                Console.WriteLine(message);
                using (StreamWriter writer = new StreamWriter(ProcessingLogFileName, true))
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
                if (this.IsRunConsole == true)
                    Console.WriteLine(message);
            }
            catch
            {
                Console.WriteLine("ERROR PROCESSING FOLDER!!!PLEASE RELOAD THE PROGRAMM");
            }
        }
    }
}
