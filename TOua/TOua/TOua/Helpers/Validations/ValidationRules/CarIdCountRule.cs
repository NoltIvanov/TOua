using TOua.Helpers.Validations.Contracts;

namespace TOua.Helpers.Validations.ValidationRules {
    public class CarIdCountRule<T> : IValidationRule<T> {

        private const int MIN_LENGTH = 3;

        public string ValidationMessage { get; set; }

        public bool Check(T value) {
            if (value == null) return false;

            var str = value as string;

            if (str.Length < MIN_LENGTH) {
                return false;
            }

            return true;
        }
    }
}
