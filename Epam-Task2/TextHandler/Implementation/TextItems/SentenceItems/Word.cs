﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public class Word : ISentenceItem
    {
        private char[] letters;
        public char[] Symbols
        {
            get
            {
                return letters;
            }
            set
            {
                letters=value;
            }
        }
        public override string ToString()
        {            
            return string.Join("", Symbols);
        }
    }
}

