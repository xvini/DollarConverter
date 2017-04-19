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
    public class BelowThousandToStringTest
    {
        [TestMethod]
        public void Call_IBelowHundredToString()
        {
            CheckBelowHundredCall(99, 99);
        }

        [TestMethod]
        public void Call_IDigitToString_For_Hundred()
        {
            // Arrange
            var test = new TestContainer();

            const int ExpectedDigit = 7;
            bool called = false;
            test.DigitToString.Setup(m => m.GetStringForDigit(ExpectedDigit))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<BelowThousandToString>();

            // Act
            converter.GetStringForBelowThousand(ExpectedDigit * 100);

            // Assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Check_500()
        {
            // Arrange
            var test = new TestContainer();
            test.DigitToString.Setup(m => m.GetStringForDigit(5)).Returns("five");

            var converter = test.RegisterAll().Resolve<BelowThousandToString>();

            // Act
            var result = converter.GetStringForBelowThousand(500);

            // Assert
            Assert.AreEqual("five hundred", result);
        }

        [TestMethod]
        public void Check_431()
        {
            CheckBelowHundredCall(31, 431);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<BelowThousandToString>();

            // Act
            var ex = TestAssistant.GetException(() => converter.GetStringForBelowThousand(1000));

            // Assert
            Assert.IsNotNull(ex);
        }

        private void CheckBelowHundredCall(int expectedValue, int callValue)
        {
            // Arrange
            var test = new TestContainer();

            bool called = false;
            test.BelowHundredToString.Setup(m => m.GetStringForBelowHundred(expectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<BelowThousandToString>();

            // Act
            converter.GetStringForBelowThousand(callValue);

            // Assert
            Assert.IsTrue(called);
        }
    }
}
