using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOua.ViewModels.Base;

namespace TOua.ViewModels.ActionBars {
    public class CommonActionBarViewModel : ActionBarBaseViewModel {

        bool _isBackButtonAvailable;
        public bool IsBackButtonAvailable {
            get { return _isBackButtonAvailable; }
            private set { SetProperty(ref _isBackButtonAvailable, value); }
        }

        public override Task InitializeAsync(object navigationData) {

            IsBackButtonAvailable = NavigationService.IsBackButtonAvailable;

            return base.InitializeAsync(navigationData);
        }
    }
}
