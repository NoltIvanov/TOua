using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TOua.ViewModels.ActionBars;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms.Internals;

namespace TOua.ViewModels.Base {
    public class ContentPageBaseViewModel : ViewModelBase {
        private readonly Dictionary<Guid, bool> _busySequence = new Dictionary<Guid, bool>();

        public ContentPageBaseViewModel() {
            ActionBarViewModel = DependencyLocator.Resolve<CommonActionBarViewModel>();
            ActionBarViewModel.InitializeAsync(this);
        }

        private ObservableCollection<PopupBaseViewModel> _popups = new ObservableCollection<PopupBaseViewModel>();
        public ObservableCollection<PopupBaseViewModel> Popups {
            get => _popups;
            private set => SetProperty<ObservableCollection<PopupBaseViewModel>>(ref _popups, value);
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand {
            get => _refreshCommand;
            protected set => SetProperty<ICommand>(ref _refreshCommand, value);
        }

        private bool _isPullToRefreshEnabled;
        public bool IsPullToRefreshEnabled {
            get => _isPullToRefreshEnabled;
            protected set => SetProperty<bool>(ref _isPullToRefreshEnabled, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing {
            get => _isRefreshing;
            set => SetProperty<bool>(ref _isRefreshing, value);
        }

        private bool _isPopupsVisible;
        public bool IsPopupsVisible {
            get => _isPopupsVisible;
            set => SetProperty<bool>(ref _isPopupsVisible, value);
        }

        private ActionBarBaseViewModel _actionBarViewModel;
        public ActionBarBaseViewModel ActionBarViewModel {
            get => _actionBarViewModel;
            protected set => SetProperty(ref _actionBarViewModel, value);
        }

        public override void Dispose() {
            base.Dispose();

            ActionBarViewModel?.Dispose();
        }

        public void SetBusy(Guid guidKey, bool isBusy) {
            if (_busySequence.ContainsKey(guidKey)) {
                _busySequence[guidKey] = isBusy;
            }
            else {
                _busySequence.Add(guidKey, isBusy);
            }

            _busySequence.Where(kVP => !kVP.Value).Select(kVP => kVP.Key).ToArray().ForEach(g => _busySequence.Remove(g));

            IsBusy = _busySequence.Any();
        }
    }
}