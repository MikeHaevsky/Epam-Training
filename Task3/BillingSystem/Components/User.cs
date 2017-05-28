using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public class User
    {
        public String Name
        {
            get;
            set;
        }
        public TelephoneNumber number
        {
            get;
            set;
        }
        public double Balans
        {
            get;
            set;
        }
        public double Money
        {
            get;
            set;
        }
        public int TarifId
        {
            get;
            set;
        }
    }
}
