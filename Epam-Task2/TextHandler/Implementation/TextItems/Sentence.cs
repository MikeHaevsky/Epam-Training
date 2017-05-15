using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems
{
    public class Sentence//:ISentence
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
        //public Separator typeSeparator;
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
        //public Separator TypeSeparator
        //{
        //    get
        //    {
        //        return typeSeparator;
        //    }
        //}

        //public int ParagraphNumber
        //{
        //    get
        //    {
        //        return paragraphNumber;
        //    }
        //}
    }
}
