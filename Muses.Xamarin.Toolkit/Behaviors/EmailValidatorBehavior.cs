using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Behaviors
{
    /// <summary>
    /// Validation behavior which checks if the input on a Entry view is a valid email
    /// address.
    /// </summary>
    public class EmailValidatorBehavior : BaseValidatorBehavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        /// <summary>
        /// Called when the behavior is attached to it's Entry view.
        /// </summary>
        /// <param name="bindable">The entry View attached to.</param>
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Called when the behavior is detached from it's Entry view.
        /// </summary>
        /// <param name="bindable">The entry View detached from.</param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Helper which validates the entered text for a valid email address.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool valid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            IsValid = valid;
            IsInvalid = !valid;
        }
    }
}
