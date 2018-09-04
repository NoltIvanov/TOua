using System;
using System.Threading.Tasks;
using TransportAndOwner.Services.Navigation;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TOua {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            InitApp();
        }

        private void InitApp() {
            DependencyLocator.RegisterDependencies();
        }

        private Task InitNavigation() {
            var navigationService = DependencyLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart() {
            base.OnStart();

            await InitNavigation();

            base.OnResume();
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
