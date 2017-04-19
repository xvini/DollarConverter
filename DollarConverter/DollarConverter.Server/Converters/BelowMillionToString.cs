using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class BelowMillionToString : IBelowMillionToString
    {
        private IBelowThousandToString _converter;

        public BelowMillionToString(IBelowThousandToString converter)
        {
            _converter = converter;
        }

        public string GetStringForBelowMillion(int value)
        {
            if (value > 999999)
            {
                throw new Exception("Can't convert value greater than 999 999");
            }

            if (value < 1000)
            {
                return _converter.GetStringForBelowThousand(value);
            }

            var thousand = value / 1000;
            var rest = value % 1000;

            var result = _converter.GetStringForBelowThousand(thousand) + " thousand";
            if (rest > 0)
            {
                result += " " + _converter.GetStringForBelowThousand(rest);
            }

            return result;
        }
    }
}
