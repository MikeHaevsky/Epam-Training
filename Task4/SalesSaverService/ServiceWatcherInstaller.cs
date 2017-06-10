using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SalesSaverService
{
    [RunInstaller(true)]
    public partial class ServiceWatcherInstaller :Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        public ServiceWatcherInstaller()
        {
            InitializeComponent();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "ServiceWatcher";
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
