using System;
using System.Threading.Tasks;
using TOua.Helpers;
using TransportAndOwner.Services.Dialog;
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

#if DEBUG
            TrackMemoryUsage();
#endif
        }

        private static void TrackMemoryUsage() {
            Device.StartTimer(TimeSpan.FromSeconds(5), () => {
                MemoryHelper.DisplayAndroidMemory();

                return true;
            });
        }

        private void InitApp() {
            DependencyLocator.RegisterDependencies();
        }

        private void InitNavigation() {
            INavigationService navigationService = DependencyLocator.Resolve<INavigationService>();

            navigationService.Initialize();
        }

        protected override void OnStart() {
            base.OnStart();

            InitNavigation();

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
