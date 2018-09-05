using System;
using TOua.ViewModels.Base;
using TOua.Views.Popups;

namespace TOua.ViewModels.Popups {
    public class CarInfoDetailsPopupViewModel : PopupBaseViewModel {

        private object _targetCarInfo;
        public object TargetCarInfo {
            get => _targetCarInfo;
            private set => SetProperty(ref _targetCarInfo, value);
        }

        public override Type RelativeViewType => typeof(CarInfoDetailsPopupView);

        public void ViewCarInfoDetails(object todoTargetCarModel) {
            if (todoTargetCarModel != null) {
                ShowPopupCommand.Execute(null);

                TargetCarInfo = todoTargetCarModel;
            }
        }

        protected override void OnClosePopup() {
            base.OnClosePopup();

            TargetCarInfo = null;
        }
    }
}
