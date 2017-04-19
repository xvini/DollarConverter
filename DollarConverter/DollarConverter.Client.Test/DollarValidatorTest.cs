using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace DollarConverter.Client.Test
{
    [TestClass]
    public class DollarValidatorTest
    {
        [TestMethod]
        public void Accept_Comma_As_Decimal_Separator()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("123,45", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Accept_Maximum()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("999999999,99", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Accept_Input_With_Spaces()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("999 999", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Accept_Two_Decimal_Digits()
        {
            // Arrange
            var validate = new DollarValidator();

            // Act
            var result = validate.Validate("1,23", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Reject_Dot_As_Decimal_Separator()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("123.45", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Reject_Negative_Values()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("-1", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Reject_Three_Decimal_Digits()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("1,123", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Reject_Values_Greater_Than_Maximum()
        {
            // Arrange
            var validator = new DollarValidator();

            // Act
            var result = validator.Validate("1000000000", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
        }
    }
}
