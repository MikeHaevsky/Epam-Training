using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems;

namespace TextHandler.Interfaces
{
    public interface ISentence
    {
        ICollection<ISentenceItem> Items
        {
            get;
            set;
        }
        Separator TypeSeparator 
        {
            get;
        }
    }
}
