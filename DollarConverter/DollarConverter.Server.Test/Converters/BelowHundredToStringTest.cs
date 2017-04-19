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
    public class BelowHundredToStringTest
    {
        [TestMethod]
        public void Call_IBelowTwentyToString()
        {
            // Arrange
            var test = new TestContainer();

            const int ExpectedValue = 19;
            bool called = false;
            test.BelowTwentyToString.Setup(m => m.GetStringForBelowTwenty(ExpectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<BelowHundredToString>();

            // Act
            converter.GetStringForBelowHundred(ExpectedValue);

            // Assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Call_IDigitToString()
        {
            // Arrange
            var test = new TestContainer();

            const int ExpectedDigit = 7;
            bool called = false;
            test.DigitToString.Setup(m => m.GetStringForDigit(ExpectedDigit))
                .Returns(() =>
                {
                    called = true;
                    return "seven";
                });

            var converter = test.RegisterAll().Resolve<BelowHundredToString>();

            // Act
            var result = converter.GetStringForBelowHundred(30 + ExpectedDigit);

            // Assert
            Assert.AreEqual("thirty-seven", result);
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Check_Value_20()
        {
            Check("twenty", 20);
        }

        [TestMethod]
        public void Check_Value_30()
        {
            Check("thirty", 30);
        }

        [TestMethod]
        public void Check_Value_40()
        {
            Check("forty", 40);
        }

        [TestMethod]
        public void Check_Value_50()
        {
            Check("fifty", 50);
        }

        [TestMethod]
        public void Check_Value_60()
        {
            Check("sixty", 60);
        }

        [TestMethod]
        public void Check_Value_70()
        {
            Check("seventy", 70);
        }

        [TestMethod]
        public void Check_Value_80()
        {
            Check("eighty", 80);
        }

        [TestMethod]
        public void Check_Value_90()
        {
            Check("ninety", 90);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            var container = new TestContainer().RegisterAll().Resolve<BelowHundredToString>();

            // Act
            var ex = TestAssistant.GetException(() => container.GetStringForBelowHundred(100));

            // Assert
            Assert.IsNotNull(ex);
        }

        private void Check(string expected, int value)
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<BelowHundredToString>();

            // Act
            var result = converter.GetStringForBelowHundred(value);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
