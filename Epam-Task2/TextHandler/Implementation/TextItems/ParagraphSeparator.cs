using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems
{
    class ParagraphSeparator: ITextItem
    {
        public string sentenceSeparator;
        public ParagraphSeparator()
        {
            //this.sentenceSeparator=new string[2] {"\r","\n"};

            this.sentenceSeparator = "\r\n";
            //this.sentenceSeparator = new ParagraphSeparator();
        }
        //public string SentenceSeparator
        //{
        //    get
        //    {
        //        return  _sentenceSeparator;
        //    }
        //}

        //public string Chars
        //{
        //    get
        //    {
        //        return sentenceSeparator;
        //    }
        //}
    }
}
