using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class BelowTwentyToString : IBelowTwentyToString
    {
        private static readonly IDictionary<int, string> _values = new Dictionary<int, string>
        {
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" }
        };

        private IDigitToString _digitConverter;

        public BelowTwentyToString(IDigitToString digitConverter)
        {
            _digitConverter = digitConverter;
        }

        public string GetStringForBelowTwenty(int value)
        {
            if (value > 19)
            {
                throw new Exception("Converter can't handle values greater than 19");
            }

            if (value < 10)
            {
                return _digitConverter.GetStringForDigit(value);
            }

            return _values[value];
        }
    }
}
