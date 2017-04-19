using DollarConverter.Server.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DollarConverter.Server.Test.Converters
{
    [TestClass]
    public class DollarsToStringTest
    {
        [TestMethod]
        public void Call_INumberToString_For_Cents()
        {
            CheckNumberToStringCall(33, 0.33m);
        }

        [TestMethod]
        public void Call_INumberToString_For_Dollars()
        {
            CheckNumberToStringCall(555, 555m);
        }

        [TestMethod]
        public void Append_Cent_Word_For_One_Cent()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<DollarsToString>();

            // Act
            var result = converter.GetStringForDollars(0.01m);

            // Assert
            Assert.IsTrue(result.EndsWith("cent"));
        }

        [TestMethod]
        public void Append_Cents_Word()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<DollarsToString>();

            // Act
            var result = converter.GetStringForDollars(0.10m);

            // Assert
            Assert.IsTrue(result.EndsWith("cents"));
        }

        [TestMethod]
        public void Append_Dollar_Word_For_One_Dollar()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<DollarsToString>();

            // Act
            var result = converter.GetStringForDollars(1m);

            // Assert
            Assert.IsTrue(result.EndsWith("dollar"));
        }

        [TestMethod]
        public void Append_Dollars_Word()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<DollarsToString>();

            // Act
            var result = converter.GetStringForDollars(2m);

            // Assert
            Assert.IsTrue(result.EndsWith("dollars"));
        }

        private void CheckNumberToStringCall(int expectedValue, decimal callValue)
        {
            // Arrange
            var test = new TestContainer();

            bool called = false;
            test.NumberToString.Setup(m => m.GetStringForNumber(expectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<DollarsToString>();

            // Act
            converter.GetStringForDollars(callValue);

            // Assert
            Assert.IsTrue(called);
        }
    }
}
