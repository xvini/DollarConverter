using DollarConverter.Server.Converters;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server
{
    internal class Container : UnityContainer
    {
        public static readonly Container Global = new Container();

        public Container()
        {
            this.RegisterType<IDigitToString, DigitToString>();
            this.RegisterType<IDollarsToString, DollarsToString>();
            this.RegisterType<IBelowTwentyToString, BelowTwentyToString>();
            this.RegisterType<IBelowHundredToString, BelowHundredToString>();
            this.RegisterType<IBelowThousandToString, BelowThousandToString>();
            this.RegisterType<IBelowMillionToString, BelowMillionToString>();
            this.RegisterType<INumberToString, NumberToString>();
        }
    }
}
