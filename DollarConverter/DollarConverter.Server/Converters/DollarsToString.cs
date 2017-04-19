using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal class DollarsToString : IDollarsToString
    {
        private INumberToString _numberConverter;

        public DollarsToString(INumberToString numberConverter)
        {
            _numberConverter = numberConverter;
        }

        public string GetStringForDollars(decimal value)
        {
            int dollars = (int)value;

            var builder = new StringBuilder();
            builder.Append(_numberConverter.GetStringForNumber(dollars));
            builder.Append(dollars == 1 ? " dollar" : " dollars");

            int cents = (int)((value - dollars) * 100);
            if (cents > 0)
            {
                builder.Append(" and ");
                builder.Append(_numberConverter.GetStringForNumber(cents));
                builder.Append(cents == 1 ? " cent" : " cents");
            }

            return builder.ToString(); ;
        }
    }
}
