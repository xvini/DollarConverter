using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal interface IDollarsToString
    {
        string GetStringForDollars(decimal value);
    }
}
