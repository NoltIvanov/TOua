using System.Threading.Tasks;
using System.Windows.Input;
using TOua.ViewModels.Base;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels {
    public sealed class MainViewModel : ContentPageBaseViewModel {

        string _name = "Hello world";
        public string Name {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ICommand TestCommand => new Command(async () => await DialogService.ToastAsync("Test in developing"));

        /// <summary>
        ///     ctor().
        /// </summary>
        public MainViewModel() {

        }

        public override Task InitializeAsync(object navigationData) {
            return base.InitializeAsync(navigationData);
        }
    }
}
