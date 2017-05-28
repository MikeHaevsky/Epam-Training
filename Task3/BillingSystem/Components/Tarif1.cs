using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public class Tarif1:ITarif
    {
        //public double GetCoastSession(int time)
        //{
        //    return time*0.5/60;
        //}
        //public void DebitMoney(double sum)
        //{
            
        //}

        double ITarif.GetCoastSession(int time)
        {
            return time * 0.5 / 60;
        }

        void ITarif.DebitMoney(double sum)
        {
            throw new NotImplementedException();
        }
    }
}
