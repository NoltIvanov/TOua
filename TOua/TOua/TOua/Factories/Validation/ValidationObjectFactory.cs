using TOua.Helpers.Validations;

namespace TOua.Factories.Validation {
    public class ValidationObjectFactory : IValidationObjectFactory {
        public ValidatableObject<T> GetValidatableObject<T>() {
            return new ValidatableObject<T>();
        }
    }
}
