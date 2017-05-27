using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    class Channel
    {
        public int ID
        {
            get;
            set;
        }
        public TelephoneNumber InNumber
        {
            get;
            set;
        }
        public TelephoneNumber OutNumber
        {
            get;
            set;
        }
        public Channel(int id,TelephoneNumber innumber,TelephoneNumber outnumber)
        {
            this.ID = id;
            this.InNumber = innumber;
            this.OutNumber = outnumber;
        }
    }
}
