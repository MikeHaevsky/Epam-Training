using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Exchanges
{
    public class FilterDetalization:EventArgs
    {
        public FilterTypes Type
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
        public FilterDetalization(FilterTypes type, string value)
        {
            Type = type;
            Value = value;
        }


    }
}
