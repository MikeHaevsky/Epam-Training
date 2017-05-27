using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    public class TelephoneNumber//:EventArgs
    {
        public short _code;
        public int _number;
        public short Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        public TelephoneNumber(short code, int number)
        {
            if (code < 99|code>999)
                throw new ArgumentException("Code cann not contains more then 2 numerics");
            if (number > 9999999|number<999999)
                throw new ArgumentException("Number cann not contains more then 6 numerics");
            else
            {
                this._code = code;
                this._number = number;
            }
        }
    }
}
