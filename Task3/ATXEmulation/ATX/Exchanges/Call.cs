﻿using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Exchanges
{
    public class Call :EventArgs,ISession
    {

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

        public DateTime StartTimeSession
        {
            get;
            set;
        }
        public DateTime EndTimeSession
        {
            get;
            set;
        }

        public SessionStatusValue Status
        {
            get;
            set;
        }
        //must be TimeSpan but...
        //public int TimeOverSeconds
        //{
        //    get;
        //    set;
        //}
        public double Coast
        {
            get;
            set;
        }
        public TimeSpan Duration
        {
            get;
            set;
        }
        public void GetDuration()
        {
            Duration = EndTimeSession - StartTimeSession;
        }
    }
}
