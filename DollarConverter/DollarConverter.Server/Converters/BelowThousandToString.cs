using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class BelowThousandToString : IBelowThousandToString
    {
        private IDigitToString _digitConverter;
        private IBelowHundredToString _hundredConverter;

        public BelowThousandToString(IDigitToString digitConverter, IBelowHundredToString hundredConverter)
        {
            _digitConverter = digitConverter;
            _hundredConverter = hundredConverter;
        }

        public string GetStringForBelowThousand(int value)
        {
            if (value > 999)
            {
                throw new Exception("Can't convert values greater than 999");
            }

            if (value < 100)
            {
                return _hundredConverter.GetStringForBelowHundred(value);
            }

            int hundred = value / 100;
            int rest = value % 100;
            var result = _digitConverter.GetStringForDigit(hundred) + " hundred";
            if (rest > 0)
            {
                result += " " + _hundredConverter.GetStringForBelowHundred(rest);
            }

            return result;
        }
    }
}
