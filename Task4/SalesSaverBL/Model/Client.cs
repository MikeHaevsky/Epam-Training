using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL.Model
{
    public class Client
    {
        public int Id
        {
            get;
            set;
        }
        public string Nickname
        {
            get;
            set;
        }
        public Client(string nickname)
        {
            Nickname = nickname;
        }
    }
}
