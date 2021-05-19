using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreLibrary.Tests
{
    public class LatitudeValidatorTests
    {
        [Theory]
        [InlineData("90.0001")]
        [InlineData("-90.0001")]
        [InlineData("900.0001")]
        [InlineData("-900.0001")]
        [InlineData("91.1")]
        [InlineData("-91.1")]
        [InlineData("91")]
        [InlineData("-91")]
        public void IsValidLatitude_CorrectFormatInvalidValues_ReturnsFalse(string latitude)
        {
            // Arrange
            ILatitudeValidator validator = new LatitudeValidator();
            bool expected = false;

            // Act
            bool actual = validator.IsValidLatitude(latitude);

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
        public void IsValidLatitude_IncorrectFormat_ReturnsFalse(string latitude)
        {
            // Arrange
            ILatitudeValidator validator = new LatitudeValidator();
            bool expected = false;

            // Act
            bool actual = validator.IsValidLatitude(latitude);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("90")]
        [InlineData("90.0")]
        [InlineData("-90")]
        [InlineData("-90.0")]
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
        public void IsValidLatitude_ValidValues_ReturnsTrue(string latitude)
        {
            // Arrange
            ILatitudeValidator validator = new LatitudeValidator();
            bool expected = true;

            // Act
            bool actual = validator.IsValidLatitude(latitude);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
