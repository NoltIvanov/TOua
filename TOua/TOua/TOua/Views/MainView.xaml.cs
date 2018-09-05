using TOua.Views.Base;
using Xamarin.Forms.Xaml;

namespace TransportAndOwner.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPageBaseView {
        public MainView() {
            InitializeComponent();
            //_todo.BackgroundColor = Xamarin.Forms.Color.FromHex("#fbfbfb");

        }
    }
}