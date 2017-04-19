using DollarConverter.Server.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server.Test.Converters
{
    [TestClass]
    public class DigitToStringTest
    {
        [TestMethod]
        public void Check_Digit_0()
        {
            Check("zero", 0);
        }

        [TestMethod]
        public void Check_Digit_1()
        {
            Check("one", 1);
        }

        [TestMethod]
        public void Check_Digit_2()
        {
            Check("two", 2);
        }

        [TestMethod]
        public void Check_Digit_3()
        {
            Check("three", 3);
        }

        [TestMethod]
        public void Check_Digit_4()
        {
            Check("four", 4);
        }

        [TestMethod]
        public void Check_Digit_5()
        {
            Check("five", 5);
        }

        [TestMethod]
        public void Check_Digit_6()
        {
            Check("six", 6);
        }

        [TestMethod]
        public void Check_Digit_7()
        {
            Check("seven", 7);
        }

        [TestMethod]
        public void Check_Digit_8()
        {
            Check("eight", 8);
        }

        [TestMethod]
        public void Check_Digit_9()
        {
            Check("nine", 9);
        }

        [TestMethod]
        public void Fail_If_Negative()
        {
            // Arrange
            IDigitToString converter = new DigitToString();

            // Act
            var ex = TestAssistant.GetException(() => converter.GetStringForDigit(-1));

            // Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Fail_If_Too_Big()
        {
            // Arrange
            IDigitToString converter = new DigitToString();

            // Act
            var ex = TestAssistant.GetException(() => converter.GetStringForDigit(10));

            // Assert
            Assert.IsNotNull(ex);
        }

        private void Check(string expected, int digit)
        {
            // Arrange
            IDigitToString converter = new DigitToString();

            // Act
            var result = converter.GetStringForDigit(digit);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
