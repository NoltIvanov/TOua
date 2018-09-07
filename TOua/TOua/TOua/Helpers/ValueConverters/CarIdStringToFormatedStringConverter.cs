using System;
using System.Globalization;
using Xamarin.Forms;

namespace TOua.Helpers.ValueConverters {
    public class CarIdStringToFormatedStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            FormattedString formattedString = new FormattedString();

            if (value != null && value is string targetValue) {
                if (targetValue.Length == 8) {

                    string firstSegment = targetValue.Substring(0, 2);
                    string secondSegment = targetValue.Substring(2, targetValue.Length - 4);
                    string thirdSegment = targetValue.Substring(targetValue.Length - 2, 2);

                    if (LetterNumberCheck(firstSegment, true) && LetterNumberCheck(secondSegment, false) && LetterNumberCheck(thirdSegment, true)) {
                        formattedString.Spans.Add(new Span() { Text = firstSegment.ToUpper() });
                        formattedString.Spans.Add(new Span() { Text = string.Format(" {0} ", secondSegment.ToUpper()) });
                        formattedString.Spans.Add(new Span() { Text = thirdSegment.ToUpper() });
                    }
                    else {
                        formattedString.Spans.Add(new Span() { Text = targetValue });
                    }
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

        private bool LetterNumberCheck(string value, bool isLettersCheck) {
            for (int i = 0; i < value.Length - 1; i++) {
                char tarhetChar = value[i];

                if (isLettersCheck) {
                    if (!Char.IsLetter(value[i])) {
                        return false;
                    }
                }
                else {
                    if (!Char.IsNumber(value[i])) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

