using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Events
{
    class TerminalEventArgs
    {
        public string consoleMessage;
        public TerminalEventArgs(string message)
        {
            consoleMessage = message;
        }
    }
}
