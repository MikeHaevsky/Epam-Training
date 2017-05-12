using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Implementation.TextItems.SentenceItems
{
    public struct Symbol
    {
        public string _particeles;
        public string Chars
        {
            get
            {
                return _particeles;
            }
            set
            {
                _particeles=value;
            }
        }
        public Symbol(string chars)
        {
            _particeles = chars;
        }

        public Symbol(char source)
        {
            _particeles = source.ToString();
        }
    }
}
