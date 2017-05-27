using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public class OtherSymbols:ISentenceItem
    {
        private char[] symbols;
        public char[] Symbols
        {
            get
            {
                return symbols;
            }
            set
            {
                symbols = value;
            }
        }
        public override string ToString()
        {
            return string.Join("", symbols);
        }

    }
}
