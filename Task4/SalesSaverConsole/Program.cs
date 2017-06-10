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
            Logger logger=new Logger();
            logger.RunConsole = true;
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
            Console.ReadKey(true);
            //loggerThread.s
        }
    }
}
