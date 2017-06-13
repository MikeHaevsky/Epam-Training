using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class FolderWatcher
    {
        public bool IsRunConsole
        {
            get;
            set;
        }
        FileSystemWatcher watcher;
        bool enabled = true;
        private WatcherLogger WatLogger
        {
            get;
            set;
        }
        public FolderWatcher()
        {
            BLHelper.InitializeSetting("WorkFolder");
            if (!Directory.Exists(BLHelper.FolderSetting))
            {
                Directory.CreateDirectory(BLHelper.FolderSetting);
            }
            watcher = new FileSystemWatcher(BLHelper.FolderSetting, Resource.WatchedExtension);
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
        }
        public void Start()
        {
            WatLogger = new WatcherLogger();
            WatLogger.IsRunConsole = this.IsRunConsole;
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Task.Run(() => RunProcessing(e.FullPath));
        }
        private void RunProcessing(string filePath)
        {
            string fileEvent = "added";
            WatLogger.RecordEntry(fileEvent, filePath);
            Handler handler = new Handler();
            handler.ProcessedCSV(filePath,IsRunConsole);
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "deleted";
            string filePath = e.FullPath;
            WatLogger.RecordEntry(fileEvent, filePath);
        }
        
    }
}
