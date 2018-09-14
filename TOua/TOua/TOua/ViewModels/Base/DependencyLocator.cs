using Autofac;
using System;
using System.Globalization;
using System.Reflection;
using TOua.Factories.Validation;
using TOua.Services.CarsInfo;
using TOua.Services.Memory;
using TOua.Services.RequestProvider;
using TOua.ViewModels;
using TOua.ViewModels.ActionBars;
using TOua.ViewModels.Popups;
using TransportAndOwner.Services.Dialog;
using TransportAndOwner.Services.Navigation;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels.Base {
    public static class DependencyLocator {

        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
          BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(DependencyLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();

            // View models.
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<CarInfoDetailsPopupViewModel>();
            builder.RegisterType<CommonActionBarViewModel>();
            builder.RegisterType<FoundCarsInfoViewModel>();

            // Services.
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<RequestProvider>().As<IRequestProvider>().SingleInstance();
            builder.RegisterType<CarsInfoService>().As<ICarsInfoService>();

            // test.
            builder.RegisterType<ResilientRequestProvider>().As<IResilientRequestProvider>().SingleInstance();

            // Factories.
            builder.RegisterType<ValidationObjectFactory>().As<IValidationObjectFactory>();

            if (_container != null) {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>() => _container.Resolve<T>();

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue) {
            var view = bindable as Element;
            if (view == null) return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) return;

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
