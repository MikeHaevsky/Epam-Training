using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public class Digit: ISentenceItem
    {
        public char[] symbols;
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
        //public Digit(string chars)
        //{
        //    if (chars != null)
        //    {
        //        this.symbols = chars.Select(x => new Symbol(x)).ToArray();
        //    }
        //    else
        //    {
        //        this.symbols = null;
        //    }
        //}

        //public string Symbols
        //{
        //    get
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (var s in this.symbols)
        //        {
        //            sb.Append(s.Chars);
        //        }
        //        return sb.ToString();
        //    }
        //    set
        //    {
        //        Console.WriteLine("Digit");
        //    }
        //}
    }
}
