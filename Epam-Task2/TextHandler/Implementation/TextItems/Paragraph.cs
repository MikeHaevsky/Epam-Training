using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems
{
    class Paragraph:ITextItem
    {
        public ICollection<Sentence> Items { get; set; }
        public Paragraph()
        {
            Items = new List<Sentence>();
        }
        public Paragraph(IEnumerable<Sentence> source)
            : this()
        {
            foreach (var c in source)
            {
                Items.Add(c);
            }
        }
        //public string Chars
        //{
        //    get
        //    {
        //        return Items;
        //    }
        //}
    }
}
