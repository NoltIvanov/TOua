﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.ViewModels.Base;
using TOua.ViewModels.Popups;
using TransportAndOwner.ViewModels.Base;
using Xamarin.Forms;

namespace TOua.ViewModels {
    public class FoundCarsInfoViewModel : ContentPageBaseViewModel {

        private CancellationTokenSource _getCarsCancellationTokenSource = new CancellationTokenSource();

        public ICommand ViewCarInfoDetailsCommand => new Command((object param) => {
            TestPopupViewModel.ViewCarInfoDetails(param);
        });

        private string _targetCarId;
        public string TargetCarId {
            get => _targetCarId;
            private set => SetProperty<string>(ref _targetCarId, value);
        }

        private List<object> _foundCars = new List<object>();
        public List<object> FoundCars {
            get => _foundCars;
            private set => SetProperty<List<object>>(ref _foundCars, value);
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
                TargetCarId = navigationData.ToString();
                GetCarsInfo();
            }

            TestPopupViewModel?.InitializeAsync(navigationData);

            return base.InitializeAsync(navigationData);
        }

        public override void Dispose() {
            base.Dispose();

            TestPopupViewModel?.Dispose();
            ResetCancellationTokenSource(ref _getCarsCancellationTokenSource);
        }

        private async void GetCarsInfo() {
            ResetCancellationTokenSource(ref _getCarsCancellationTokenSource);
            CancellationTokenSource cancellationTokenSource = _getCarsCancellationTokenSource;

            Guid busyKey = Guid.NewGuid();
            SetBusy(busyKey, true);

            try {
                await Task.Delay(900);
                FoundCars = new List<object>() { new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object(), new object() };
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
