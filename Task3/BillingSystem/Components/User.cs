using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public class User:EventArgs
    {
        public String Name
        {
            get;
            set;
        }
        public TelephoneNumber Number
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
        public User(string name, TelephoneNumber number, int tarifId)
        {
            Name = name;
            Number = number;
            TarifId = tarifId;
        }
    }
}
