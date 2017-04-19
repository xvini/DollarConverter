using DollarConverter.Server.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DollarConverter.Server.Test.Converters
{
    [TestClass]
    public class BelowTwentyToStringTest
    {
        [TestMethod]
        public void Call_IDigitToString_For_Below_Ten()
        {
            // Arrange
            var test = new TestContainer();

            bool called = false;
            const int ExpectedValue = 9;
            test.DigitToString.Setup(m => m.GetStringForDigit(ExpectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<BelowTwentyToString>();

            // Act
            converter.GetStringForBelowTwenty(ExpectedValue);

            // Assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Check_Value_10()
        {
            Check("ten", 10);
        }

        [TestMethod]
        public void Check_Value_11()
        {
            Check("eleven", 11);
        }

        [TestMethod]
        public void Check_Value_12()
        {
            Check("twelve", 12);
        }

        [TestMethod]
        public void Check_Value_13()
        {
            Check("thirteen", 13);
        }

        [TestMethod]
        public void Check_Value_14()
        {
            Check("fourteen", 14);
        }

        [TestMethod]
        public void CHeck_Value_15()
        {
            Check("fifteen", 15);
        }

        [TestMethod]
        public void Check_Value_16()
        {
            Check("sixteen", 16);
        }

        [TestMethod]
        public void Check_Value_17()
        {
            Check("seventeen", 17);
        }

        [TestMethod]
        public void Check_Value_18()
        {
            Check("eighteen", 18);
        }

        [TestMethod]
        public void Check_Value_19()
        {
            Check("nineteen", 19);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            var container = new TestContainer().RegisterAll().Resolve<BelowTwentyToString>();

            // Act
            var ex = TestAssistant.GetException(() => container.GetStringForBelowTwenty(20));

            // Assert
            Assert.IsNotNull(ex);
        }

        private void Check(string expected, int value)
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<BelowTwentyToString>();

            // Act
            var result = converter.GetStringForBelowTwenty(value);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
