using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Exchanges
{
    public class TextMessage:EventArgs, ISession
    {
        public string Message
        {
            get;
            set;
        }
        public TextMessage(string message)
        {
            Message = message;
        }

        public TelephoneNumber FirstAbonent
        {
            get;
            set;
        }

        public TelephoneNumber SecondAbonent
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public SessionStatusValue Status
        {
            get;
            set;
        }
        public double Coast
        {
            get;
            set;
        }
    }
}
