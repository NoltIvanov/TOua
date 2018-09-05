using System;
using TOua.ViewModels.Base;
using TOua.Views.Popups;

namespace TOua.ViewModels.Popups {
    public class CarInfoDetailsPopupViewModel : PopupBaseViewModel {

        public override Type RelativeViewType => typeof(CarInfoDetailsPopupView);
    }
}
