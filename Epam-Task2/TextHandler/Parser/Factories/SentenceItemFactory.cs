using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Parser.Factories
{
    class SentenceItemFactory:ISentenceItemFactory
    {
        private ISentenceItemFactory wordFactory;
        //private ISentenceItemFactory punctuationFactory;
        private ISentenceItemFactory wordSeparator;
        public ISentenceItem Create(string chars)
        {
            //ISentenceItem result = punctuationFactory.Create(chars);
            ISentenceItem result = wordFactory.Create(chars);
            if (result != null)
            {
                result = wordFactory.Create(chars);
            }
            return result;
        }
        public SentenceItemFactory(ISentenceItemFactory punctuationFactory, ISentenceItemFactory wordFactory,ISentenceItemFactory wordSeparator)
        {
            //this.punctuationFactory = punctuationFactory;
            this.wordFactory = wordFactory;
            this.wordSeparator = wordSeparator;
        }
        //    switch(chars){
        //        case "_punctuationFactory":
        //            return new PunctuationFactory(symbol);
        //            break;
        //        case "_wordFactory":
        //            return new WordFactory(symbol);
        //            break;
        //        default:
        //            break;
        //    }
            //ISentenceItem result=this._punctuationFactory.Create(chars);
            //return result;
        //public ISentenceItemFactory(ISentenceItemFactory punctuationFactory, ISentenceItemFactory wordFactory)
        //{
        //    _punctuationFactory=punctuationFactory;
        //    _wordFactory=wordFactory;
        //    if (_wordFactory==null)
        //    {
        //        return _punctuationFactory;
        //    }
        //    else
        //    {
        //        return _wordFactory;
        //    }
        //}
    }
}
