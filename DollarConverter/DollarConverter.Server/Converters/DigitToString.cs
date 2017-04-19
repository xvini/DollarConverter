using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class DigitToString : IDigitToString
    {
        private static readonly IDictionary<int, string> _values = new Dictionary<int, string>
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" }
        };

        public string GetStringForDigit(int digit)
        {
            if (digit < 0)
            {
                throw new Exception("Value can't be negative");
            }

            if (digit > 9)
            {
                throw new Exception("Value can't be bigger than 9");
            }

            return _values[digit];
        }
    }
}
