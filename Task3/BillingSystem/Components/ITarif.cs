using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public interface ITarif
    {
        string Tittle
        {
            get;
            set;
        }
        double GetCoastSession(int duration);
    }
}
