﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Interfaces
{
    public interface ISentenceItem
    {
        char[] Symbols
        {
            get;
            set;
        }
        //string ToString();
        //string OfType();
    }
}
