using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Events
{
    class PortEventArgs
    {
        public string consoleMessage;
        public PortEventArgs(string message)
        {
            consoleMessage = message;
        }
    }
}
