using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muses.Xamarin.Toolkit.Behaviors;
using System;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Tests
{
    /// <summary>
    /// This class is just covering the basics here. It is nearly impossible
    /// to have a RegEx that correctly validates all correct and incorrect
    /// email addresses. Since the <see cref="EmailValidatorBehavior"/> class
    /// does a RegEx validation this should suffice for now.
    /// </summary>
    [TestClass]
    public class EmailValidatorBehaviorTests
    {
        private String[] _valid =
        {
            "email@example.com",
            "firstname.lastname@example.com",
            "email@subdomain.example.com",
            "email@123.123.123.123",
            "email@[123.123.123.123]",
            "1234567890@example.com",
            "email@example-one.com",
            "email@example.name",
            "email@example.museum",
            "email@example.co.jp"
        };

        private String[] _invalid =
        {
            "",
            "plainaddress",
            "#@%^%#$@#$@#.com",
            "@example.com",
            "Joe Smith <email@example.com>",
            "email.example.com",
            "email@example@example.com",
            ".email@example.com",
            "email.@example.com",
            "email..email@example.com",
            "あいうえお@example.com",
            "email@example.com (Joe Smith)",
            "email@example",
            "email@-example.com",
            "email@example..com",
            "Abc..123@example.com",
            "“(),:;<>[\\]@example.com",
            "just\"not\"right @example.com",
            "this\\ is\"really\"not\\allowed @example.com"
        };


        [TestMethod]
        public void EmailValidator_Valid_IsValid()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new EmailValidatorBehavior();
            entry.Behaviors.Add(behavior);

            foreach (var m in _valid)
            {
                // Act
                entry.Text = m;

                // Assert
                Assert.IsTrue(behavior.IsValid, m);
                Assert.IsFalse(behavior.IsInvalid, m);
            }
        }

        [TestMethod]
        public void EmailValidator_Invalid_IsInvalid()
        {
            // Arrange.
            var entry = new Entry();
            var behavior = new EmailValidatorBehavior();
            entry.Behaviors.Add(behavior);

            foreach (var m in _invalid)
            {
                // Act
                entry.Text = m;

                // Assert
                Assert.IsFalse(behavior.IsValid, m);
                Assert.IsTrue(behavior.IsInvalid, m);
            }
        }
    }
}
