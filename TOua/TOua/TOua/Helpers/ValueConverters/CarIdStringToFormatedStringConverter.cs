using System;
using System.Globalization;
using Xamarin.Forms;

namespace TOua.Helpers.ValueConverters {
    public class CarIdStringToFormatedStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            FormattedString formattedString = new FormattedString();

            if (value != null && value is string targetValue) {
                if (targetValue.Length > 4) {
                    formattedString.Spans.Add(new Span() { Text = targetValue.Substring(0, 2) });
                    formattedString.Spans.Add(new Span() { Text = targetValue.Substring(2, targetValue.Length - 4) });
                    formattedString.Spans.Add(new Span() { Text = targetValue.Substring(targetValue.Length - 2, 2) });
                }
                else {
                    formattedString.Spans.Add(new Span() { Text = targetValue });
                }
            }

            return formattedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException("CarIdStringToFormatedStringConverter.ConvertBack");
        }
    }
}
