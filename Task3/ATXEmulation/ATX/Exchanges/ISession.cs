﻿using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Exchanges
{
    public interface ISession
    {
        TelephoneNumber FirstAbonent
        {
            get;
            set;
        }
        TelephoneNumber SecondAbonent
        {
            get;
            set;
        }
        DateTime StartTimeSession
        {
            get;
            set;
        }
        SessionStatusValue Status
        {
            get;
            set;
        }
        double Coast
        {
            get;
            set;
        }
    }
}
