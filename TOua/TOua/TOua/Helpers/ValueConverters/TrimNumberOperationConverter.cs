using System;
using System.Globalization;
using Xamarin.Forms;

namespace TOua.Helpers.ValueConverters {
    public sealed class TrimNumberOperationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string result = value as string;

            return result.Substring(result.IndexOf('-') + 1).TrimStart();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
