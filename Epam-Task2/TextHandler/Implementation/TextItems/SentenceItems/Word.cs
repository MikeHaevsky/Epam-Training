using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public class Word : ISentenceItem
    {
        public char[] letters;
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
        //public Word(string chars)
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
        //public Symbol GetSymbol(int i)
        //{
        //    return symbols[i];
        //}
        //public string Chars
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
        //        Console.WriteLine("WordItem");
        //    }
        //}
        //    public IEnumerator<Symbol> GetEnumerator()
        //    {
        //        //foreach (var s in symbols)
        //        //{
        //        //    yield return s;
        //        //}

        //        return symbols.AsEnumerable().GetEnumerator();
        //    }
        //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //    {
        //        return this.symbols.GetEnumerator();
        //    }
        //    public int Length
        //    {
        //        get { return (symbols != null) ? symbols.Length : 0; }
        //    }
        //}
    }
}

