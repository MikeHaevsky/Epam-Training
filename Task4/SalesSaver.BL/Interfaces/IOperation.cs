using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaver.BL.Interfaces
{
    interface IOperation
    {
        int Id
        {
            get;
            set;
        }
        int Manager
        {
            get;
            set;
        }
        int Client
        {
            get;
            set;
        }
        int Product
        {
            get;
            set;
        }
        int Quantity
        {
            get;
            set;
        }
        int TotalSum
        {
            get;
            set;
        }
        DateTime Date
        {
            get;
            set;
        }
    }
}
