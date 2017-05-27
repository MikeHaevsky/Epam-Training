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
    public class Text
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
        public Text(IEnumerable<Sentence> item)
            : this()
        {
            foreach (var c in item)
            {
                TextItems.Add(c);
            }
        }
        public string GroupByParagraph()
        {
            return string.Join("\n", textItems.GroupBy(x => x.ParagraphNumber).Select(x => string.Join(" ", x.Select(y => y.ToString()))));
        }
        //Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них
        public IOrderedEnumerable<Sentence> Query1()
        {
            return TextItems.OrderBy(items=>items.WordCount());
        }

        //Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
        public string Query2()
        {
            return string.Join("\n", TextItems.Where(x => x.IsQuestion() == true).Select(x => string.Join("",x.Items)));
        }
    }
}
