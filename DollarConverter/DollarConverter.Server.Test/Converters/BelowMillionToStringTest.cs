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
    public class BelowMillionToStringTest
    {
        [TestMethod]
        public void Call_IBelowThousandToString()
        {
            CheckBelowThousandCall(999, 999);
        }

        [TestMethod]
        public void Check_5000()
        {
            // Arrange
            var test = new TestContainer();
            test.BelowThousandToString.Setup(m => m.GetStringForBelowThousand(5)).Returns("five");

            var converter = test.RegisterAll().Resolve<BelowMillionToString>();

            // Act
            var result = converter.GetStringForBelowMillion(5000);

            // Assert
            Assert.AreEqual("five thousand", result);
        }

        [TestMethod]
        public void Check_6444()
        {
            CheckBelowThousandCall(444, 5444);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<BelowMillionToString>();

            // Act
            var ex = TestAssistant.GetException(() => converter.GetStringForBelowMillion(1000000));

            // Assert
            Assert.IsNotNull(ex);
        }

        private void CheckBelowThousandCall(int expectedValue, int callValue)
        {
            // Arrange
            var test = new TestContainer();

            bool called = false;
            test.BelowThousandToString.Setup(m => m.GetStringForBelowThousand(expectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<BelowMillionToString>();

            // Act
            converter.GetStringForBelowMillion(callValue);

            // Assert
            Assert.IsTrue(called);

        }
    }
}
