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
    public class NumberToStringTest
    {
        [TestMethod]
        public void Call_IBelowMillionToString()
        {
            // Arrange
            var test = new TestContainer();

            const int ExpectedValue = 333444;
            bool called = false;
            test.BelowMillionToString.Setup(m => m.GetStringForBelowMillion(ExpectedValue))
                .Returns(() =>
                {
                    called = true;
                    return string.Empty;
                });

            var converter = test.RegisterAll().Resolve<NumberToString>();

            // Act
            converter.GetStringForNumber(ExpectedValue);

            // Assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Call_IBelowThousandToString()
        {
            // Arrange
            var test = new TestContainer();

            const int ExpectedValue = 2;
            bool called = false;
            test.BelowThousandToString.Setup(m => m.GetStringForBelowThousand(ExpectedValue))
                .Returns(() =>
                {
                    called = true;
                    return "two";
                });

            var converter = test.RegisterAll().Resolve<NumberToString>();

            // Act
            var result = converter.GetStringForNumber(ExpectedValue * 1000000);

            // Assert
            Assert.IsTrue(called);
            Assert.AreEqual("two million", result);
        }

        [TestMethod]
        public void Check_2000007()
        {
            // Arrange
            var test = new TestContainer();
            test.BelowMillionToString.Setup(m => m.GetStringForBelowMillion(7)).Returns("seven");
            test.BelowThousandToString.Setup(m => m.GetStringForBelowThousand(2)).Returns("two");
            var converter = test.RegisterAll().Resolve<NumberToString>();

            // Act
            var result = converter.GetStringForNumber(2000007);

            // Assert
            Assert.AreEqual("two million seven", result);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            var converter = new TestContainer().RegisterAll().Resolve<NumberToString>();

            // Act
            var ex = TestAssistant.GetException(() => converter.GetStringForNumber(1000000000));

            // Assert
            Assert.IsNotNull(ex);
        }
    }
}
