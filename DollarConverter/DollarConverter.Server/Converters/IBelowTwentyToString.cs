using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Converters
{
    internal interface IBelowTwentyToString
    {
        string GetStringForBelowTwenty(int value);
    }
}
