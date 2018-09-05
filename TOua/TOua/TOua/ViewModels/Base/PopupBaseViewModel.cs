using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.Controls.Popups;
using Xamarin.Forms;

namespace TOua.ViewModels.Base {
    public abstract class PopupBaseViewModel : NestedViewModel, IPopupContext {

        private bool _isPopupVisible;
        public bool IsPopupVisible {
            get => _isPopupVisible;
            set {
                SetProperty<bool>(ref _isPopupVisible, value);

                OnIsPopupVisible();
            }
        }

        public ICommand ShowPopupCommand => new Command(() => {
            UpdatePopupScopeVisibility(true);
            IsPopupVisible = true;
        });
        
        public ICommand ClosePopupCommand => new Command(() => {
            UpdatePopupScopeVisibility(false);
        });

        public abstract Type RelativeViewType { get; }

        public override Task InitializeAsync(object navigationData) {
            if (navigationData is ContentPageBaseViewModel pageBaseViewModel) {
                if (!pageBaseViewModel.Popups.Contains(this)) {
                    pageBaseViewModel.Popups.Add(this);
                }
            }

            return base.InitializeAsync(navigationData);
        }

        protected virtual void OnIsPopupVisible() { }
    }
}
