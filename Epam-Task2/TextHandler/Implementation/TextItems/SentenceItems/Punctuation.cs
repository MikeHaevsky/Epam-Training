﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    class Punctuation:ISentenceItem
    {
        public Symbol[] symbols;
        public Punctuation(string chars)
        {
            if (chars != null)
            {
                this.symbols = chars.Select(items=>new Symbol(items)).ToArray();
            }
            else
            {
                this.symbols=null;
            }
        }

        public string Chars
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in this.symbols)
                {
                    sb.Append(s.Chars);
                }
                return sb.ToString();
            }
            set
            {
                Console.WriteLine("PunctuationItem");
            }
        }
    }
}
