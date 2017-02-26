using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Behaviors
{
    /// <summary>
    /// A base class for validation behaviors. The this class defines two bind-able
    /// properties which describe the valid and the invalid state of the validation.
    /// Derived classes should set the properties appropriately.
    /// </summary>
    /// <typeparam name="T">The type for the behavior.</typeparam>
    public class BaseValidatorBehavior<T> : Behavior<T> where T : BindableObject
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(BaseValidatorBehavior<T>), false);
        static readonly BindablePropertyKey IsInvalidPropertyKey = BindableProperty.CreateReadOnly("IsInvalid", typeof(bool), typeof(BaseValidatorBehavior<T>), true);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
        public static readonly BindableProperty IsInvalidProperty = IsInvalidPropertyKey.BindableProperty;

        /// <summary>
        /// Gets or sets the IsValid flag for the validation behavior.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return (bool)base.GetValue(IsValidProperty);
            }

            protected set
            {
                if (IsValid != value)
                {
                    base.SetValue(IsValidPropertyKey, value);
                    IsInvalid = !value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the IsInvalid flag for the validation behavior.
        /// </summary>
        public bool IsInvalid
        {
            get
            {
                return (bool)base.GetValue(IsInvalidProperty);
            }

            protected set
            {
                if (IsInvalid != value)
                {
                    base.SetValue(IsInvalidPropertyKey, value);
                    IsValid = !value;
                }
            }
        }
    }
}
