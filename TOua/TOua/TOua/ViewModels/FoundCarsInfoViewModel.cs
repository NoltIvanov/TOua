using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.Exceptions;
using TOua.Helpers;
using TOua.Models.DTOs;
using TOua.Services.CarsInfo;
using TOua.ViewModels.Base;
using TOua.ViewModels.Popups;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;

namespace TOua.ViewModels {
    public class FoundCarsInfoViewModel : ContentPageBaseViewModel {

        private readonly ICarsInfoService _carsInfoService;

        private CancellationTokenSource _getCarsCancellationTokenSource = new CancellationTokenSource();

        public FoundCarsInfoViewModel(ICarsInfoService carsInfoService) {
            _carsInfoService = carsInfoService;
        }

        public ICommand ViewCarInfoDetailsCommand => new Command((object param) => {
            CarInfoDetailsPopupViewModel.ViewCarInfoDetails(param as CarinfoDTO);
        });

        private string _targetCarId;
        public string TargetCarId {
            get => _targetCarId;
            private set => SetProperty<string>(ref _targetCarId, value);
        }

        private string _informText;
        public string InformText {
            get => _informText;
            private set => SetProperty<string>(ref _informText, value);
        }

        private List<CarinfoDTO> _foundCars;
        public List<CarinfoDTO> FoundCars {
            get => _foundCars;
            private set => SetProperty(ref _foundCars, value);
        }

        private CarInfoDetailsPopupViewModel _testPopupViewModel;
        public CarInfoDetailsPopupViewModel CarInfoDetailsPopupViewModel {
            get => _testPopupViewModel;
            set {
                _testPopupViewModel?.Dispose();

                SetProperty(ref _testPopupViewModel, value);
            }
        }

        public override Task InitializeAsync(object navigationData) {
            if (CarInfoDetailsPopupViewModel == null) {
                CarInfoDetailsPopupViewModel = DependencyLocator.Resolve<CarInfoDetailsPopupViewModel>();
                CarInfoDetailsPopupViewModel.InitializeAsync(this);
            }

            /// TODO: Temporary implementation
            if (navigationData is string) {
                TargetCarId = navigationData.ToString();
                GetCarsInfo(TargetCarId);
            }

            CarInfoDetailsPopupViewModel?.InitializeAsync(navigationData);

            return base.InitializeAsync(navigationData);
        }

        public override void Dispose() {
            base.Dispose();

            CarInfoDetailsPopupViewModel?.Dispose();
            ResetCancellationTokenSource(ref _getCarsCancellationTokenSource);
        }

        private async void GetCarsInfo(string targetCarId) {
            ResetCancellationTokenSource(ref _getCarsCancellationTokenSource);
            CancellationTokenSource cancellationTokenSource = _getCarsCancellationTokenSource;

            Guid busyKey = Guid.NewGuid();
            SetBusy(busyKey, true);

            try {
                FoundCars = await _carsInfoService.GetCarsInfoByCarIdAsync(targetCarId, cancellationTokenSource);

                InformText = FoundCars == null || !(FoundCars.Any()) ? AppConsts.MESSAGE_NO_RESULTS : string.Empty;
            }
            catch (OperationCanceledException ex) { Debug.WriteLine($"ERROR: {ex.Message}"); }
            catch (ObjectDisposedException ex) { Debug.WriteLine($"ERROR: {ex.Message}"); }
            catch (ConnectivityException ex) {
                InformText = ex.Message;
            }
            catch (Exception ex) {
                InformText = "Сервіс тимчасово не доступний";
            }

            SetBusy(busyKey, false);
        }
    }
}
