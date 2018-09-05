using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TOua.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonCompounded : ContentView {

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(ICommand));

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(string));

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ButtonCompounded),
            defaultValue: 14.0);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(Color));

        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ButtonBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(Color));

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: nameof(BorderColor),
            returnType: typeof(Color),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(Color));

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            propertyName: nameof(CornerRadius),
            returnType: typeof(int),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(int));

        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
            propertyName: nameof(BorderThickness),
            returnType: typeof(float),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(float),
            propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                if (bindable is ButtonCompounded declarer) {

                    try {
                    declarer._mainContentSpot_Grid.Margin = new Thickness((double)((float)newValue));

                    }
                    catch (Exception exc) {

                        throw;
                    }
                }
            });

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(ImageSource),
            declaringType: typeof(ButtonCompounded),
            defaultValue: default(ImageSource),
            propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                if (bindable is ButtonCompounded declarer) {

                    try {
                    declarer._buttonImage_CachedImage.Source = (ImageSource)newValue;

                    if (newValue != null) {
                        Grid.SetColumn(declarer._buttonImage_CachedImage, 2);
                    }
                    else {
                        Grid.SetColumn(declarer._buttonImage_CachedImage, 0);
                    }

                    }
                    catch (Exception) {

                        throw;
                    }
                }
            });

        public ButtonCompounded() {
            InitializeComponent();

            _buttonText_Label.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
            _buttonText_Label.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));
            _buttonText_Label.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));

            _mainContentBox_ExtendedContentView.SetBinding(ExtendedContentView.BackgroundColorProperty, new Binding(nameof(ButtonBackgroundColor), source: this));
            _mainContentBox_ExtendedContentView.SetBinding(ExtendedContentView.BorderColorProperty, new Binding(nameof(BorderColor), source: this));
            _mainContentBox_ExtendedContentView.SetBinding(ExtendedContentView.CornerRadiusProperty, new Binding(nameof(CornerRadius), source: this));
            _mainContentBox_ExtendedContentView.SetBinding(ExtendedContentView.BorderThicknessProperty, new Binding(nameof(BorderThickness), source: this));

            VerticalOptions = LayoutOptions.Start;
            HorizontalOptions = LayoutOptions.Start;
        }

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double FontSize {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Color ButtonBackgroundColor {
            get { return (Color)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }

        public Color BorderColor {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public int CornerRadius {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public float BorderThickness {
            get { return (float)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public ImageSource Image {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        private void OnMainContentBoxTapped(object sender, EventArgs e) => Command?.Execute(null);
    }
}