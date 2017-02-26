using System;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Behaviors
{
    /// <summary>
    /// Validation behavior which checks if the input on a Entry view is not empty.
    /// </summary>
    public class NotEmptyBehavior : BaseValidatorBehavior<Entry>
    {
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
        /// Helper which validates the entered text for an empty text or a text
        /// with only white spaces.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool valid = !String.IsNullOrWhiteSpace(e.NewTextValue);
            IsValid = valid;
            IsInvalid = !valid;
        }
    }
}
