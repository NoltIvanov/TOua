using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TOua.Factories.Validation;
using TOua.Helpers;
using TOua.Helpers.Validations;
using TOua.Helpers.Validations.Contracts.ValidationRules;
using TOua.Helpers.Validations.ValidationRules;
using TOua.Services.Memory;
using TOua.ViewModels;
using TOua.ViewModels.Base;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels {
    public sealed class MainViewModel : ContentPageBaseViewModel {

        private static readonly string _CAR_ID_IS_REQUIRED_ERROR_MESSAGE = "Введіть номер транспортного засобу";

        private readonly IValidationObjectFactory _validationObjectFactory;

        public MainViewModel(IValidationObjectFactory validationObjectFactory) {
            _validationObjectFactory = validationObjectFactory;

            ResetValidationObjects();
        }
       
        public ICommand FindCarInfoCommand => new Command(async () => {
            if (ValidateForm()) {
                Guid busyKey = Guid.NewGuid();
                SetBusy(busyKey, true);

                await NavigationService.NavigateToAsync<FoundCarsInfoViewModel>(CarId.Value.ValidateCarNumber());

                SetBusy(busyKey, false);
            }
        });

        private ValidatableObject<string> _carId;
        public ValidatableObject<string> CarId {
            get => _carId;
            set => SetProperty(ref _carId, value);
        }

        public override Task InitializeAsync(object navigationData) {
            ResetValidationObjects();

            return base.InitializeAsync(navigationData);
        }

        private bool ValidateForm() {
            CarId.Validate();

            bool validationResult = CarId.IsValid;

            return validationResult;
        }

        private void ResetValidationObjects() {
            CarId = _validationObjectFactory.GetValidatableObject<string>();
            CarId.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = _CAR_ID_IS_REQUIRED_ERROR_MESSAGE });
            CarId.Validations.Add(new CarIdCountRule<string> { ValidationMessage = AppConsts.ERROR_CAR_NUMBER_COUNT });
            CarId.Validations.Add(new SpecificSymbolsRule<string> { ValidationMessage = AppConsts.ERROR_ALPHANUMERIC_SYMBOLS });
#if DEBUG
            CarId.Value = "ВХ4831СЕ";
#endif
        }
    }
}
