using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Components
{
    public class Tarif2:ITarif
    {
        private string _tittle;
        public int Period = 60;
        public string Tittle
        {
            get
            {
                return _tittle;
            }
            set
            {
                _tittle = "Tarif 1.65 by the minutes";
            }
        }
        public double GetCoastSession(int duration)
        {
            return duration * 1.65/ 60;
        }
    }
}
