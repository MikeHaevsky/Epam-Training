using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public class WordSeparator:ISentenceItem
    {
        private char[] symbol;
        public char[] Symbols
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }
        public override string ToString()
        {
            return string.Join("", Symbols.ToArray());
        }
    }
}
