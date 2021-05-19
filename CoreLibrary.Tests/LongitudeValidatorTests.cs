using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreLibrary.Tests
{
    public class LongitudeValidatorTests
    {
        [Theory]
        [InlineData("180.0001")]
        [InlineData("-180.0001")]
        [InlineData("900.0001")]
        [InlineData("-900.0001")]
        [InlineData("181.1")]
        [InlineData("-181.1")]
        [InlineData("181")]
        [InlineData("-181")]
        public void IsValidLongitude_CorrectFormatInvalidValues_ReturnsFalse(string longitude)
        {
            // Arrange
            ILongitudeValidator validator = new LongitudeValidator();
            bool expected = false;

            // Act
            bool actual = validator.IsValidLongitude(longitude);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("10.")]
        [InlineData("10,")]
        [InlineData("m.41")]
        [InlineData("70,5")]
        [InlineData("70.7854m")]
        [InlineData("70m.7854m")]
        [InlineData("m70.7854m")]
        [InlineData("m70.m7854")]
        [InlineData("70.-7854")]
        [InlineData("70,-7854")]
        [InlineData(".7854")]
        [InlineData(",7854")]
        [InlineData(".7854m")]
        [InlineData(",7854m")]
        [InlineData("m.m")]
        [InlineData("m,m")]
        [InlineData("m.")]
        [InlineData("m,")]
        [InlineData(".m")]
        [InlineData(",m")]
        [InlineData(".")]
        [InlineData(",")]
        public void IsValidLongitude_IncorrectFormat_ReturnsFalse(string longitude)
        {
            // Arrange
            ILongitudeValidator validator = new LongitudeValidator();
            bool expected = false;

            // Act
            bool actual = validator.IsValidLongitude(longitude);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("180")]
        [InlineData("180.0")]
        [InlineData("-180")]
        [InlineData("-180.0")]
        [InlineData("0")]
        [InlineData("-0")]
        [InlineData("0.0")]
        [InlineData("-0.0")]
        [InlineData("10")]
        [InlineData("-10")]
        [InlineData("10.0")]
        [InlineData("-10.0")]
        [InlineData("10.1546")]
        [InlineData("-10.1546")]
        public void IsValidLongitude_ValidValues_ReturnsTrue(string longitude)
        {
            // Arrange
            ILongitudeValidator validator = new LongitudeValidator();
            bool expected = true;

            // Act
            bool actual = validator.IsValidLongitude(longitude);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
