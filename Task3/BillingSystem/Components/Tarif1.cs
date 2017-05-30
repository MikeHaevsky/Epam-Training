using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public class Tarif1:ITarif
    {
        private string _tittle;
        public int Period=1;
        public string Tittle
        {
            get
            {
                return _tittle;
            }
            set
            {
                _tittle="Tarif 0.5 by the minutes";
            }
        }
        public double GetCoastSession(int duration)
        {
            return duration * 0.5 / 60;
        }
    }
}
