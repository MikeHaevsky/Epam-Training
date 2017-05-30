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
        public DateTime RegistrationDate
        {
            get;
            private set;
        }
        public User(string name, TelephoneNumber number, int tarifId)
        {
            Name = name;
            Number = number;
            TarifId = tarifId;
            RegistrationDate = DateTime.Now;
        }
        public void DebitMoney()
        {
            Money = Money - Balans;
        }
        public bool IsUserNeedLock()
        {
            if ((Money < 0) && (DateTime.Now > RegistrationDate.AddMonths(1)))
                return true;
            else
                return false;
        }
    }
}
