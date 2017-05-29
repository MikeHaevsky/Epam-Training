using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public interface ITarif
    {
        double GetCoastSession(int duration);
        void DebitMoney(double sum);
    }
}
