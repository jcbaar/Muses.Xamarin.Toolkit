using System;
using Xamarin.Forms;

namespace Muses.Xamarin.Toolkit.Converters
{
    // <summary>
    /// Simple converter which will invert a boolean value.
    /// </summary>
    public class InvertBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Inverts the given value if it is a boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to convert to (bool).</param>
        /// <param name="parameter">The parameter for the conversion.</param>
        /// <param name="culture">The culture to convert for.</param>
        /// <returns>The inverted value of the boolean or the input value if the value is not a boolean.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        /// <summary>
        /// Reverts the given value if it is a boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to convert to (bool).</param>
        /// <param name="parameter">The parameter for the conversion.</param>
        /// <param name="culture">The culture to convert for.</param>
        /// <returns>The reverted value of the boolean or the input value if the value is not a boolean.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
