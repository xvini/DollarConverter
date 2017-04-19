using DollarConverter.Server.Converters;
using Microsoft.Practices.Unity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Test
{
    internal class TestContainer : UnityContainer
    {
        public Mock<IBelowHundredToString> BelowHundredToString = new Mock<IBelowHundredToString>();
        public Mock<IBelowMillionToString> BelowMillionToString = new Mock<IBelowMillionToString>();
        public Mock<IBelowThousandToString> BelowThousandToString = new Mock<IBelowThousandToString>();
        public Mock<IBelowTwentyToString> BelowTwentyToString = new Mock<IBelowTwentyToString>();
        public Mock<IDigitToString> DigitToString = new Mock<IDigitToString>();
        public Mock<INumberToString> NumberToString = new Mock<INumberToString>();

        public TestContainer RegisterAll()
        {
            this.RegisterInstance(BelowHundredToString.Object);
            this.RegisterInstance(BelowMillionToString.Object);
            this.RegisterInstance(BelowThousandToString.Object);
            this.RegisterInstance(BelowTwentyToString.Object);
            this.RegisterInstance(DigitToString.Object);
            this.RegisterInstance(NumberToString.Object);
            return this;
        }
    }
}
