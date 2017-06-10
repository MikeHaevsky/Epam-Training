using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL.Model
{
    public class Operation
    {
        public DateTime Data
        {
            get;
            set;
        }
        public int ManagerId
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }
        public int ProductId
        {
            get;
            set;
        }
        public int Cost
        {
            get;
            set;
        }
    }
}
