using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems.SentenceItems;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems
{
    public class Sentence
    {
        public ICollection<ISentenceItem> items;
        public int paragraphNumber;
        public ICollection<ISentenceItem> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public int ParagraphNumber
        {
            get
            {
                return paragraphNumber;
            }
            set
            {
                paragraphNumber = value;
            }
        }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }

        public Sentence(IEnumerable<ISentenceItem> source)
            : this()
        {
            foreach (var c in source)
            {
                Items.Add(c);
            }
        }
        public int WordCount()
        {
            return Items.OfType<Word>().Count();
        }

        public bool IsQuestion()
        {
            char[] ch;
            int n = Items.Last().Symbols.Length - 1;
            ch = new char[n];
            ch = Items.Last().Symbols;
            if (ch.Last() == '?')
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return string.Join("", Items);
        }
    }
}
