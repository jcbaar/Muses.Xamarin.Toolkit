using System;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Behaviors
{
    /// <summary>
    /// Validation behavior which checks if the input on a Entry in no longer than a specific length.
    /// </summary>
    public class MaxLengthValidatorBehavior : BaseValidatorBehavior<Entry>
    {
        private int _maxLength = 0;

        /// <summary>
        /// Gets or sets the maximum input length of an Entry. 
        /// </summary>
        public int MaxLength
        {
            get
            {
                return _maxLength;
            }

            set
            {
                // A MaxLength of 0 is unrestricted entry. Do not add this
                // behavior with a MaxLength <= 0 because that effectively
                // disables it's functionality. If you want that simply do not
                // add this behavior in the first place.
                if(value <= 0)
                {
                    _maxLength = 0;
                }
                else
                {
                    _maxLength = value;
                }
            }
        }

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
        /// Helper which validates the entered text for a valid length.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if(MaxLength > 0 && e.NewTextValue.Length > MaxLength)
            {
                Entry entry = (Entry)sender;
                entry.TextChanged -= HandleTextChanged;
                if (String.IsNullOrEmpty(e.OldTextValue))
                {
                    entry.Text = e.NewTextValue.Substring(0, MaxLength);
                }
                else
                {
                    entry.Text = e.OldTextValue;
                }
                entry.TextChanged += HandleTextChanged;
            }
        }
    }
}
