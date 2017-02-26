using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muses.Xamarin.Toolkit.Converters;
using System;
using System.Globalization;

namespace Muses.Xamarin.Toolkit.Tests
{
    [TestClass]
    public class InvertBooleanConverterTests
    {
        [TestMethod]
        public void InvertBoolean_Convert()
        {
            // Arrange
            InvertBooleanConverter converter = new InvertBooleanConverter();

            // Act 
            bool resultT = (bool)converter.Convert(true, typeof(Boolean), null, CultureInfo.CurrentCulture);
            bool resultF = (bool)converter.Convert(false, typeof(Boolean), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(resultT);
            Assert.IsTrue(resultF);
        }

        [TestMethod]
        public void InvertBoolean_WrongType_ReturnInput()
        {
            // Arrange
            InvertBooleanConverter converter = new InvertBooleanConverter();
            object wrongType = new object();

            // Act
            object result = converter.Convert(wrongType, typeof(Boolean), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.AreSame(wrongType, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void InvertBoolean_ConvertBack()
        {
            // Arrange
            InvertBooleanConverter converter = new InvertBooleanConverter();

            // Act and assert.
            converter.ConvertBack(true, typeof(Boolean), null, CultureInfo.CurrentCulture);
        }
    }
}
