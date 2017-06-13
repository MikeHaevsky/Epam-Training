using SalesSaverBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesSaverService
{
    partial class ServiceWatcher : ServiceBase
    {
        FolderWatcher folderWatcher;
        public ServiceWatcher()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            folderWatcher = new FolderWatcher();
            folderWatcher.IsRunConsole = false;
            Task.Run(() => folderWatcher.Start());
        }

        protected override void OnStop()
        {
            folderWatcher.Stop();
            Thread.Sleep(1000);
        }
    }
}
