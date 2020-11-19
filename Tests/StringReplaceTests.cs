using System;
using System.Globalization;
using Xunit;

namespace Tests
{
    public class StringReplaceTests
    {
        
        [Theory]
        [InlineData('s', '&', true)]
        [InlineData('Q', '&', false)]
        public void ReplaceChar(char oldChar, char newChar, bool isExists)
        {
            // Arrange
            string str = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";

            // Act
            string result = str.Replace(oldChar, newChar);

            // Assert
            if (isExists)
                Assert.Equal("Lorem Ip&um i& &imply dummy text of the printing and type&etting indu&try.", result);
            else
                Assert.Equal("Lorem Ipsum is simply dummy text of the printing and typesetting industry.", result);
        }

        [Theory]
        [InlineData("dummy", "test", true)]
        [InlineData("Value", "dummy", false)]
        [InlineData(null, "dummy", null)]
        [InlineData("", "dummy", null)]
        public void ReplaceString(string oldValue, string newValue, bool? isExists)
        {
            // Arrange
            string str = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            string result = null;

            // Act
            try
            {
                result = str.Replace(oldValue, newValue);
            } 
            catch(ArgumentNullException ex)
            {
                Assert.True(oldValue == null && ex is ArgumentNullException);
            }
            catch (ArgumentException ex)
            {
                Assert.True(oldValue == "" && ex is ArgumentException);
            }           

            // Assert
            if (isExists==true)
                Assert.Equal("Lorem Ipsum is simply test text of the printing and typesetting industry.", result);
            else if (isExists == false)
                Assert.Equal("Lorem Ipsum is simply dummy text of the printing and typesetting industry.", result);
        }

        [Theory]
        [InlineData("dUmmY", "test", true, "es-ES")]
        public void ReplaceStringCaseCulture(string oldValue, string newValue, bool? ignoreCase, string code)
        {
            // Arrange
            string str = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            string result = null;
           
            // Act
            try
            {
                result = str.Replace(oldValue, newValue, ignoreCase == true, new CultureInfo(code));
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(oldValue == null && ex is ArgumentNullException);
            }
            catch (ArgumentException ex)
            {
                Assert.True(oldValue == "" && ex is ArgumentException);
            }

            // Assert
            if (ignoreCase == true)
                Assert.Equal("Lorem Ipsum is simply test text of the printing and typesetting industry.", result);
            else if (ignoreCase == false)
                Assert.Equal("Lorem Ipsum is simply dummy text of the printing and typesetting industry.", result);
        }

        [Theory]
        [InlineData("dummy", "test", StringComparison.InvariantCulture)]
        public void ReplaceStringCultureComparison(string oldValue, string newValue, StringComparison comparison)
        {
            // Arrange
            string str = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            string result = null;

            // Act
            try
            {
                result = str.Replace(oldValue, newValue, comparison);
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(oldValue == null && ex is ArgumentNullException);
            }
            catch (ArgumentException ex)
            {
                Assert.True(oldValue == "" && ex is ArgumentException);
            }

            // Assert
            Assert.Equal("Lorem Ipsum is simply test text of the printing and typesetting industry.", result);            
        }

    }
}
