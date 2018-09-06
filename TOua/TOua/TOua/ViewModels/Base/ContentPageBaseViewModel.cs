using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TOua.ViewModels.Base {
    public class ContentPageBaseViewModel : ViewModelBase {
        private static readonly string _SOURCE_URL = "https://data.gov.ua/";

        private readonly Dictionary<Guid, bool> _busySequence = new Dictionary<Guid, bool>();

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

        public ICommand NavigateToSourceCommand => new Command((object param) => {
            Device.OpenUri(new Uri(_SOURCE_URL));
        });

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
            protected set {
                _actionBarViewModel?.Dispose();
                SetProperty(ref _actionBarViewModel, value);
            }
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