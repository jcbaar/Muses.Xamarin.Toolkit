using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muses.Xamarin.Toolkit.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Tests
{
    [TestClass]
    public class MaxLengthValidatorBehaviorTests
    {
        [TestMethod]
        public void MaxLengthValidator_SetMax_EqualsValue()
        {
            // Arrange.
            var behavior = new MaxLengthValidatorBehavior();

            // Act.
            behavior.MaxLength = 22;

            // Assert.
            Assert.AreEqual(22, behavior.MaxLength);
        }

        [TestMethod]
        public void MaxLengthValidator_SetMaxNegative_Equals0()
        {
            // Arrange.
            var behavior = new MaxLengthValidatorBehavior();

            // Act.
            behavior.MaxLength = -6;

            // Assert.
            Assert.AreEqual(0, behavior.MaxLength);
        }

        [TestMethod]
        public void MaxLengthValidator_SetTextMaxLength_ReturnsSetText()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new MaxLengthValidatorBehavior();
            entry.Behaviors.Add(behavior);
            behavior.MaxLength = 5;

            // Act.
            entry.Text = "12345";

            // Assert.
            Assert.AreEqual("12345", entry.Text);
        }

        [TestMethod]
        public void MaxLengthValidator_SetTextShort_ReturnsSetText()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new MaxLengthValidatorBehavior();
            entry.Behaviors.Add(behavior);
            behavior.MaxLength = 5;

            // Act.
            entry.Text = "123";

            // Assert.
            Assert.AreEqual("123", entry.Text);
        }

        [TestMethod]
        public void MaxLengthValidator_SetTextToLong_ClipsText()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new MaxLengthValidatorBehavior();
            entry.Behaviors.Add(behavior);
            behavior.MaxLength = 5;

            // Act.
            entry.Text = "123456";

            // Assert.
            Assert.AreEqual("12345", entry.Text);
        }

        [TestMethod]
        public void MaxLengthValidator_AddTextToLong_SetsOldText()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new MaxLengthValidatorBehavior();
            entry.Behaviors.Add(behavior);
            behavior.MaxLength = 5;

            // Act.
            entry.Text = "12345";
            entry.Text = "x" + entry.Text;

            // Assert.
            Assert.AreEqual("12345", entry.Text);
        }
    }
}
