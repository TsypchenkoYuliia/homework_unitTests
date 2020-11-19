using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class StringSubStringTests
    {
        [Theory]
        [InlineData(15)]
        [InlineData(-2)]
        [InlineData(75)]
        public void SubStringOne(int startIndex)
        {
            // Arrange
            string str = "It is a long established fact, that a reader will be distracted.";
            string resultNone = null;

            // Act
            try
            {
                resultNone = str.Substring(startIndex);
            } 
            catch(ArgumentOutOfRangeException ex)
            {
                Assert.True(startIndex < 0 || startIndex > str.Length);
            }

            // Assert
            if(resultNone != null)
            Assert.Equal(resultNone, "tablished fact, that a reader will be distracted.");
        }

        [Theory]
        [InlineData(15, 7)]
        [InlineData(-2, 120)]
        [InlineData(75, 4)]
        [InlineData(60, 15)]
        public void SubStringTwo(int startIndex, int length)
        {
            // Arrange
            string str = "It is a long established fact, that a reader will be distracted.";
            string resultNone = null;

            // Act
            try
            {
                resultNone = str.Substring(startIndex, length);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.True(startIndex < 0 || startIndex > str.Length || startIndex + length < 0 || startIndex + length > str.Length || length < 0);
            }

            // Assert
            if (resultNone != null)
                Assert.Equal(resultNone, "tablish");
        }
    }
}
