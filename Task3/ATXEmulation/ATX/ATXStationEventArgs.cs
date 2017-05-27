using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX
{
    class ATXStationEventArgs
    {
        public string consoleMessage;
        public ATXStationEventArgs(string message)
        {
            consoleMessage = message;
        }
    }
}
