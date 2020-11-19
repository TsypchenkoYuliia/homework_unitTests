using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class StringSplitTests
    {
        [Theory]
        [InlineData(new string[] { " ", ","}, 22, StringSplitOptions.None)]
        [InlineData(new string[] { " ", "," }, 21, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(new string[] { " ", "," }, -8, StringSplitOptions.None)]
        [InlineData(new string[] { " ", "," }, 19, (StringSplitOptions)4)]
        public void SplitOne(string []? separator, int count, StringSplitOptions options)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be distracted , by the readable content of a page when looking at its layout.";
            string[] resultNone = null;
            
            // Act
            try
            {
                resultNone = str.Split(separator, count, options);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Assert.True(count < 0);
            }
            catch(ArgumentException ex)
            {
                Assert.False(Enum.IsDefined(typeof(StringSplitOptions), options));
            }

            // Assert
            if (count > 0 && resultNone != null)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);

                switch (options)
                {
                    case StringSplitOptions.None:
                        Assert.True(Array.IndexOf(resultNone, "") > 0);
                        break;
                    case StringSplitOptions.RemoveEmptyEntries:
                        Assert.Equal(Array.IndexOf(resultNone, ""), -1);
                        break;
                }
                Assert.True(resultNone.Length == count);
            }
            
        }

        [Theory]
        [InlineData(" ", 22)]
        [InlineData(" ", -8)]
        public void SplitTwo(string? separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be  distracted, by the readable content of a page when looking at its layout.";
            string[] resultNone = null;

            // Act
            try
            {
                resultNone = str.Split(separator, count, options);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.True(count < 0 && ex is ArgumentOutOfRangeException);
            }           

            // Assert
            if (count > 0)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);
                Assert.True(Array.IndexOf(resultNone, "") > 0);
                Assert.True(resultNone.Length == count);
            }
        }

        [Theory]
        [InlineData(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(new string[] { " ", "," }, StringSplitOptions.None)]
        [InlineData(new string[] { " ", "," }, (StringSplitOptions)5)]
        public void SplitThree(string[]? separator, StringSplitOptions options)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be distracted , by the readable content of a page when looking at its layout.";
            string[] resultNone = null;

            // Act
            try
            {
                resultNone = str.Split(separator, options);
            }
            catch (ArgumentException ex)
            {
                Assert.False(Enum.IsDefined(typeof(StringSplitOptions), options));
            }

            // Assert    
            if (resultNone != null)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);

                switch (options)
                {
                    case StringSplitOptions.None:
                        Assert.True(Array.IndexOf(resultNone, "") > 0);
                        break;
                    case StringSplitOptions.RemoveEmptyEntries:
                        Assert.Equal(Array.IndexOf(resultNone, ""), -1);
                        break;
                }
            }
        }

        [Theory]
        [InlineData(new char[] { ' ', ',' }, 22, StringSplitOptions.None)]
        [InlineData(new char[] { ' ', ',' }, 21, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(new char[] { ' ', ',' }, -8, StringSplitOptions.None)]
        [InlineData(new char[] { ' ', ',' }, 19, (StringSplitOptions)9)]
        public void SplitFour(char[] separator, int count, StringSplitOptions options)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be distracted , by the readable content of a page when looking at its layout.";
            string[] resultNone = null;

            // Act
            try
            {
                resultNone = str.Split(separator, count, options);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.True(count < 0);
            }
            catch (ArgumentException ex)
            {
                Assert.False(Enum.IsDefined(typeof(StringSplitOptions), options));
            }

            // Assert
            if (count > 0 && resultNone != null)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);

                switch (options)
                {
                    case StringSplitOptions.None:
                        Assert.True(Array.IndexOf(resultNone, "") > 0);
                        break;
                    case StringSplitOptions.RemoveEmptyEntries:
                        Assert.Equal(Array.IndexOf(resultNone, ""), -1);
                        break;
                }
                Assert.True(resultNone.Length == count);
            }

        }

        [Theory]
        [InlineData(" ")]
        public void SplitFive(string? separator, StringSplitOptions options = StringSplitOptions.None)
        {
            // Arrange
            string str = "It is a long established fact.";
           
            // Act
            var resultNone = str.Split(separator, options);
                        
            // Assert
            Assert.Equal(Array.IndexOf(resultNone, separator), -1);
            Assert.Equal(resultNone, new string[] { "It", "is", "a", "long", "established", "fact." });
        }

        [Theory]
        [InlineData(new char[] { ' ', ',' }, StringSplitOptions.None)]
        [InlineData(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(new char[] { ' ', ',' }, (StringSplitOptions)7)]
        public void SplitSix(char[] separator, StringSplitOptions options)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be distracted , by the readable content of a page when looking at its layout.";
            string[] resultNone = null;

            // Act
            try
            {
                resultNone = str.Split(separator, options);
            }
            catch (ArgumentException ex)
            {
                Assert.False(Enum.IsDefined(typeof(StringSplitOptions), options));
            }

            // Assert 
            if (resultNone != null)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);

                switch (options)
                {
                    case StringSplitOptions.None:
                        Assert.True(Array.IndexOf(resultNone, "") > 0);
                        break;
                    case StringSplitOptions.RemoveEmptyEntries:
                        Assert.Equal(Array.IndexOf(resultNone, ""), -1);
                        break;
                }
            }
        }

        [Theory]
        [InlineData(' ')]
        public void SplitSeven(char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            // Arrange
            string str = "It is a long established fact.";

            // Act
            var resultNone = str.Split(separator, options);

            // Assert
            Assert.Equal(Array.IndexOf(resultNone, separator), -1);
            Assert.Equal(resultNone, new string[] { "It", "is", "a", "long", "established", "fact." });
        }

        [Theory]
        [InlineData(new char[] { ' ', ',' })]
        public void SplitEight(char[] separator)
        {
            // Arrange
            string str = "It is a long established fact, that a reader will be distracted.";

            // Act
            var resultNone = str.Split(separator);
                       
            // Assert
            Assert.Equal(Array.IndexOf(resultNone, separator), -1);
            Assert.Equal(resultNone, new string[] { "It", "is", "a", "long", "established", "fact", "","that", "a", "reader", "will", "be", "distracted." });
        }

        [Theory]
        [InlineData(new char[] { ' ', ',' }, 5)]
        public void SplitNine(char[] separator, int count)
        {
            // Arrange
            string str = "It is a long established fact, that a reader will be distracted.";

            // Act
            var resultNone = str.Split(separator, count);

            // Assert
            Assert.Equal(Array.IndexOf(resultNone, separator), -1);
            Assert.Equal(resultNone, new string[] { "It", "is", "a", "long", "established fact, that a reader will be distracted." });
            Assert.True(resultNone.Length == count);
        }

        [Theory]
        [InlineData(' ', 22)]
        [InlineData(' ', -8)]
        public void SplitTen(char separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            // Arrange
            string str = "It is a long established fact that a reader will be  distracted, by the readable content of a page when looking at its layout.";
            string[] resultNone = null;

            // Act
            try
            {
                resultNone = str.Split(separator, count, options);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.True(count < 0);
            }

            // Assert
            if (count > 0)
            {
                Assert.Equal(Array.IndexOf(resultNone, separator), -1);
                Assert.True(Array.IndexOf(resultNone, "") > 0);
                Assert.True(resultNone.Length == count);
            }
        }        
    }
}
