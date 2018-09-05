using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TransportAndOwner.Services.Dialog;
using TransportAndOwner.Services.Navigation;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels.Base {
    public abstract class ViewModelBase : ExtendedBindableObject {

        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModelBase() {
            DialogService = DependencyLocator.Resolve<IDialogService>();
            NavigationService = DependencyLocator.Resolve<INavigationService>();

            BackCommand = new Command(async () => await NavigationService.GoBackAsync());
        }

        public ICommand BackCommand { get; protected set; }

        public bool IsSubscribedOnAppEvents { get; private set; }

        bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set => SetProperty<bool>(ref _isBusy, value);
        }

        public virtual Task InitializeAsync(object navigationData) {
            if (!IsSubscribedOnAppEvents) {
                OnSubscribeOnAppEvents();
            }

            return Task.FromResult(false);
        }

        public virtual void Dispose() {
            OnUnsubscribeFromAppEvents();
        }

        protected void ResetCancellationTokenSource(ref CancellationTokenSource cancellationTokenSource) {
            cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected virtual void OnSubscribeOnAppEvents() {
            IsSubscribedOnAppEvents = true;
        }

        protected virtual void OnUnsubscribeFromAppEvents() {
            IsSubscribedOnAppEvents = false;
        }
    }
}
