using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.ViewModels.Base;
using TOua.ViewModels.Popups;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;

namespace TOua.ViewModels {
    public class FoundCarsInfoViewModel : ContentPageBaseViewModel {

        private string _searchValue;
        public string SearchValue {
            get => _searchValue;
            private set => SetProperty<string>(ref _searchValue, value);
        }

        private CarInfoDetailsPopupViewModel _testPopupViewModel;
        public CarInfoDetailsPopupViewModel TestPopupViewModel {
            get => _testPopupViewModel;
            set {
                _testPopupViewModel?.Dispose();

                SetProperty<CarInfoDetailsPopupViewModel>(ref _testPopupViewModel, value);
            }
        }

        public override Task InitializeAsync(object navigationData) {
            if (TestPopupViewModel == null) {
                TestPopupViewModel = DependencyLocator.Resolve<CarInfoDetailsPopupViewModel>();
                TestPopupViewModel.InitializeAsync(this);
            }

            /// TODO: Temporary implementation
            if (navigationData is string) {
                SearchValue = navigationData.ToString();
            }

            TestPopupViewModel?.InitializeAsync(navigationData);

            return base.InitializeAsync(navigationData);
        }

        public override void Dispose() {
            base.Dispose();

            TestPopupViewModel?.Dispose();
        }
    }
}
