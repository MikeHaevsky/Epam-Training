using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;
using TextHandler.Interfaces;

namespace TextHandler.Implementation
{
    class Text
    {
        private ICollection<Sentence> textItems;
        public ICollection<Sentence> TextItems
        {
            get
            {
                return textItems;
            }
            set
            {
                textItems = value;
            }
        }
        public Text()
        {
            TextItems = new List<Sentence>();
        }
        //public int GetCountWords(){
        //    //return textItem.OfType<Paragraph>().Count<Word>();
        //    return textItem.OfType<Paragraph>().OfType<Sentence>().OfType<Word>().Count();
        //}
        //public int CountSeprators()
        //{
        //    int c;
        //    //return this.TextItems.Count(c=>TextItems.Where(item=>item))
        //    //return (x=>TextItems.Count(x.GetType=))
        //    return textItem.OfType<ParagraphSeparator>().Count();
        //    //TextItems.Select(s => s.Paragraph);
        //    //return c.Count(x=>TextItems.Select(y=>y.);

        //}
    }
}
