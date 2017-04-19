using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class BelowHundredToString : IBelowHundredToString
    {
        private static readonly IDictionary<int, string> _tens = new Dictionary<int, string>
        {
            { 2, "twenty" },
            { 3, "thirty" },
            { 4, "forty" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" }
        };


        private IBelowTwentyToString _belowTwentyConverter;
        private IDigitToString _digitConverter;

        public BelowHundredToString(IDigitToString digitConverter, IBelowTwentyToString belowTwentyConverter)
        {
            _belowTwentyConverter = belowTwentyConverter;
            _digitConverter = digitConverter;
        }

        public string GetStringForBelowHundred(int value)
        {
            if (value > 99)
            {
                throw new Exception("Can't convert value bigger than 99");
            }

            if (value < 20)
            {
                return _belowTwentyConverter.GetStringForBelowTwenty(value);
            }

            int tens = value / 10;
            int digit = value % 10;

            var result = _tens[tens];
            if (digit > 0)
            {
                result += "-" + _digitConverter.GetStringForDigit(digit);
            }

            return result;
        }
    }
}
