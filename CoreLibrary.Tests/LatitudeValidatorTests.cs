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
    }
}
