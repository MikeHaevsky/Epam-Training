using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaver.BL.Interfaces
{
    interface IProduct
    {
        int Id
        {
            get;
            set;
        }
        string Tittle
        {
            get;
            set;
        }
        string Cost
        {
            get;
            set;
        }
        string Producer
        {
            get;
            set;
        }
    }
}
