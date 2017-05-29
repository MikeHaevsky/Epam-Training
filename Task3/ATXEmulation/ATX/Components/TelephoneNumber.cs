using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    public class TelephoneNumber:EventArgs
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
            if (code > 99 && code <999)
                throw new ArgumentException("Code must contain 3 numerics");
            if (number < 9999999 && number>999999)
                throw new ArgumentException("Number must contain 7 numerics");
            else
            {
                this._code = code;
                this._number = number;
            }
        }
        public static bool operator ==(TelephoneNumber number1, TelephoneNumber number2)
        {
            return number1.Code == number2.Code && number1.Number == number2.Number;
        }
        public static bool operator !=(TelephoneNumber number1, TelephoneNumber number2)
        {
            return !(number1==number2);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
