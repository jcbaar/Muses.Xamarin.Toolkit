using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muses.Xamarin.Toolkit.Behaviors;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Tests
{
    /// <summary>
    /// Simple test class for testing the <see cref="BaseValidatorBehavior{T}.IsValid"/>
    /// and <see cref="BaseValidatorBehavior{T}.IsInvalid"/> properties.
    /// </summary>
    internal class TestBehavior : BaseValidatorBehavior<BindableObject>
    {
        public void SetValid()
        {
            IsValid = true;
        }

        public void SetInvalid()
        {
            IsInvalid = true;
        }
    }

    [TestClass]
    public class BaseValidatorBehaviorTests
    {
        [TestMethod]
        public void BaseValidator_SetValid_InvertedInvalid()
        {
            var behavior = new TestBehavior();

            behavior.SetValid();

            Assert.IsTrue(behavior.IsValid);
            Assert.IsFalse(behavior.IsInvalid);
        }

        [TestMethod]
        public void BaseValidator_SetInValid_InvertedValid()
        {
            var behavior = new TestBehavior();

            behavior.SetInvalid();

            Assert.IsFalse(behavior.IsValid);
            Assert.IsTrue(behavior.IsInvalid);
        }
    }
}
