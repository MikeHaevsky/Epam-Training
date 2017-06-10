using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL.Model
{
    public class Manager
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
        public Manager (string nickname)
        {
            Nickname = nickname;
        }
    }
}
