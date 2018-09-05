using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace TOua.Helpers.ValueConverters {
    public class FirstItemFromCollectionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is ICollection<string> errors && errors.Count > 0 ? errors.ElementAt(0) : null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException("FirstItemFromCollectionConverter.ConvertBack");
    }
}
