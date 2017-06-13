using SalesSaverBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesSaverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderWatcher folderWatcher = new FolderWatcher();
            folderWatcher.IsRunConsole = true;
            Task.Run(() => folderWatcher.Start());
            Console.ReadKey(true);
        }
    }
}
