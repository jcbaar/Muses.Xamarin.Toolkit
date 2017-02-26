using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muses.Xamarin.Toolkit.Behaviors;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Tests
{
    [TestClass]
    public class NotEmptyBehaviorTests
    {
        [TestMethod]
        public void NotEmptyBehaviour_EmptyTest()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new NotEmptyBehavior();
            entry.Behaviors.Add(behavior);

            // Act
            entry.Text = "";

            // Assert
            Assert.IsFalse(behavior.IsValid);
            Assert.IsTrue(behavior.IsInvalid);
        }

        [TestMethod]
        public void NotEmptyBehaviour_WhiteSpaceTest()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new NotEmptyBehavior();
            entry.Behaviors.Add(behavior);

            // Act
            entry.Text = " \t \r\n";

            // Assert
            Assert.IsFalse(behavior.IsValid);
            Assert.IsTrue(behavior.IsInvalid);
        }

        [TestMethod]
        public void NotEmptyBehaviour_NotEmptyTest()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new NotEmptyBehavior();
            entry.Behaviors.Add(behavior);

            // Act
            entry.Text = " \t x \r\n";

            // Assert
            Assert.IsTrue(behavior.IsValid);
            Assert.IsFalse(behavior.IsInvalid);
        }
    }
}
