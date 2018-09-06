
using Xamarin.Forms;

namespace TOua.Controls {
    public class LabelExtended : Label {

        public static readonly BindableProperty LineHeightProperty = BindableProperty.Create(
            nameof(LineHeight),
            typeof(float),
            typeof(LabelExtended),
            defaultValue: 1F);

        public static readonly BindableProperty LetterSpacingProperty = BindableProperty.Create(
            nameof(LetterSpacing),
            typeof(float),
            typeof(LabelExtended),
            defaultValue: .05F);

        public float LineHeight {
            get => (float)GetValue(LineHeightProperty);
            set => SetValue(LineHeightProperty, value);
        }

        public float LetterSpacing {
            get => (float)GetValue(LetterSpacingProperty);
            set => SetValue(LetterSpacingProperty, value);
        }
    }
}