using System.Threading.Tasks;
using TransportAndOwner.Services.Dialog;
using TransportAndOwner.Services.Navigation;

namespace TransportAndOwner.ViewModels.Base {
    public abstract class ViewModelBase : ExtendedBindableObject {

        protected readonly IDialogService DialogService;

        protected readonly INavigationService NavigationService;

        bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ViewModelBase() {
            DialogService = DependencyLocator.Resolve<IDialogService>();
            NavigationService = DependencyLocator.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}
