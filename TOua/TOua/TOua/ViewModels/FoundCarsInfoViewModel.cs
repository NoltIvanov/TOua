using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.Models.DTOs;
using TOua.Services.CarsInfo;
using TOua.ViewModels.Base;
using TOua.ViewModels.Popups;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;

namespace TOua.ViewModels {
    public class FoundCarsInfoViewModel : ContentPageBaseViewModel {

        private static readonly string _NO_RESULTS_MESSAGE = "Інформації не знайдено";
        private static readonly string _SOURCE_URL = "https://data.gov.ua/";

        private readonly ICarsInfoService _carsInfoService;

        private CancellationTokenSource _getCarsCancellationTokenSource = new CancellationTokenSource();

        public FoundCarsInfoViewModel(ICarsInfoService carsInfoService) {
            _carsInfoService = carsInfoService;
        }

        public ICommand ViewCarInfoDetailsCommand => new Command((object param) => {
            CarInfoDetailsPopupViewModel.ViewCarInfoDetails(param as CarinfoDTO);
        });

        public ICommand NavigateToSourceCommand => new Command((object param) => {
            Device.OpenUri(new Uri(_SOURCE_URL));
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

        private List<CarinfoDTO> _foundCars = new List<CarinfoDTO>();
        public List<CarinfoDTO> FoundCars {
            get => _foundCars;
            private set => SetProperty<List<CarinfoDTO>>(ref _foundCars, value);
        }

        private CarInfoDetailsPopupViewModel _testPopupViewModel;
        public CarInfoDetailsPopupViewModel CarInfoDetailsPopupViewModel {
            get => _testPopupViewModel;
            set {
                _testPopupViewModel?.Dispose();

                SetProperty<CarInfoDetailsPopupViewModel>(ref _testPopupViewModel, value);
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
                //FoundCars = new List<CarinfoDTO>() { new CarinfoDTO() { OperName = "Rlrrlrll rlrrlrll lrllrlrr rlrrlrll lrllrlrr rlrrlrll lrllrlrr rlrrlrll lrllrlrr", OperCode = "240" } };

                InformText = FoundCars == null || !(FoundCars.Any()) ? _NO_RESULTS_MESSAGE : "";
            }
            catch (OperationCanceledException) { }
            catch (ObjectDisposedException) { }
            catch (Exception exc) {
                await DialogService.ToastAsync(exc.Message);
            }

            SetBusy(busyKey, false);
        }
    }
}
