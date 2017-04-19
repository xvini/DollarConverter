using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class NumberToString : INumberToString
    {
        private IBelowMillionToString _millionConverter;
        private IBelowThousandToString _thousandConverter;

        public NumberToString(IBelowThousandToString thousandConverter, IBelowMillionToString millionConverter)
        {
            _thousandConverter = thousandConverter;
            _millionConverter = millionConverter;
        }

        public string GetStringForNumber(int value)
        {
            if (value > 999999999)
            {
                throw new Exception("Can't convert values greater than 999 999 999");
            }

            if (value < 1000000)
            {
                return _millionConverter.GetStringForBelowMillion(value);
            }

            int million = value / 1000000;
            int rest = value % 1000000;

            var result = _thousandConverter.GetStringForBelowThousand(million) + " million";
            if (rest > 0)
            {
                result += " " + _millionConverter.GetStringForBelowMillion(rest);
            }

            return result;
        }
    }
}
