using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Implementation.TextItems.TextItems.SentenceItems
{
    public class WordSeparator:ISentenceItem
    {
        public string wordSeparator;
        public WordSeparator()
        {
            this.wordSeparator = " ";
        }

        public string Chars
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
