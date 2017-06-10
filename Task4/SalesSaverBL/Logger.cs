﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class Logger
    {
        public bool RunConsole;
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Logger()
        {
            if (!Directory.Exists(Resource.WorkFolder))
            {
                Directory.CreateDirectory(Resource.WorkFolder);
            }
            watcher = new FileSystemWatcher(Resource.WorkFolder,Resource.WatchedExtension);
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }
        public void Start()
        {
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
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "renamed on " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
            if (this.RunConsole == true)
                Console.WriteLine("File {0} was {1} and processed",filePath,fileEvent);
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "edited";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            if (this.RunConsole == true)
                Console.WriteLine("File {0} was {1} and processed", filePath, fileEvent);
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "added";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            if (this.RunConsole == true)
                Console.WriteLine("File {0} was {1} and processed", filePath, fileEvent);
            Handler handler = new Handler();
            handler.ReadCSV(filePath);
            //filePath.ReadCSV().WriteLog();
            //CSVHandler.CSVReader reader = new CSVHandler.CSVReader(filePath);
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "deleted";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            if (this.RunConsole == true)
                Console.WriteLine("File {0} was {1}", filePath, fileEvent);
        }
        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(Resource.LogFile, true))
                {
                    writer.WriteLine(String.Format("{0} file {1} has {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
        private void ReadWrite(object FilePath)
        {
            Thread.Sleep(1000);
            //CSVHandler.CSVReader reader = new CSVHandler.CSVReader(FilePath);
        }
    }
}