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
    public class Text//:IComparable
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
        public string GroupByParagraph()
        {
            //return string.Join("\n", textItems.GroupBy(x => x.ParagraphNumber));
            //return string.Join("\n", text.Query1().GroupBy(x => x.ParagraphNumber).Select(x => x.ToString()));
            //return TextItems.GroupBy(items=>items.ParagraphNumber).Select(;
            return string.Join("\n", textItems.GroupBy(x => x.ParagraphNumber).Select(x => string.Join(" ", x.Select(y => y.ToString()))));
        }
        //public override string ToString()
        //{
        //    return string.Join("\n", TextItems.GroupBy(x => x.ParagraphNumber).Select(x => string.Join(" ", x.Select(y => y.ToString()))));
        //    //return string.Join("\n",textItems);
        //}
        //Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них
        public IOrderedEnumerable<Sentence> Query1()
        {
            return TextItems.OrderBy(items=>items.WordCount());
        }

        //Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
        public string Query2()
        {
            //return string.Join("\n", TextItems.Where(x => x.IsQuestion() == true).Select(x => string.Join(" ",x.Select(y=>y.ToString()))));
            return string.Join("\n", TextItems.Where(x => x.IsQuestion() == true).Select(x => string.Join("",x.Items)));//x.Items));
            //return string.Join("\n", TextItems.Select(x => x.IsQuestion()));
        }

        //public int CompareTo(Sentence sen)
        //{
        //    int compare;
        //    compare=String.Compare(this.textItems)
        //}
        //public string GetText()
        //{
        //    foreach (Sentence item in textItems)
        //    {
                
        //        if(item.)
        //    }
        //}

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
