using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using TransportAndOwner.ViewModels;
using TransportAndOwner.ViewModels.Base;
using TransportAndOwner.Views;
using Xamarin.Forms;

namespace TransportAndOwner.Services.Navigation {
    public class NavigationService : INavigationService {
        public ViewModelBase PreviousPageViewModel {
            get {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }

        public Task InitializeAsync() {
            return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter) {
            Page page = CreatePage(viewModelType, parameter);

            if (page is MainView) {
                Application.Current.MainPage = new CustomNavigationView(page);
            } else {
                var navigationPage = Application.Current.MainPage as CustomNavigationView;
                if (navigationPage != null) {
                    await navigationPage.PushAsync(page);
                } else {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType) {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter) {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
