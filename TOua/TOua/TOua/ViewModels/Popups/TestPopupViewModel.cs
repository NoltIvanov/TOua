using System;
using TOua.Models.DTOs;
using TOua.ViewModels.Base;
using TOua.Views.Popups;

namespace TOua.ViewModels.Popups {
    public class CarInfoDetailsPopupViewModel : PopupBaseViewModel {

        private CarinfoDTO _targetCarInfo;
        public CarinfoDTO TargetCarInfo {
            get => _targetCarInfo;
            private set => SetProperty(ref _targetCarInfo, value);
        }

        public override Type RelativeViewType => typeof(CarInfoDetailsPopupView);

        public void ViewCarInfoDetails(CarinfoDTO targetCarInfo) {
            if (targetCarInfo != null) {
                ShowPopupCommand.Execute(null);

                TargetCarInfo = targetCarInfo;
            }
        }

        protected override void OnClosePopup() {
            base.OnClosePopup();

            TargetCarInfo = null;
        }
    }
}
