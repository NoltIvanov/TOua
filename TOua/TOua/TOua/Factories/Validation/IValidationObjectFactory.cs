using TOua.Helpers.Validations;

namespace TOua.Factories.Validation {
    public interface IValidationObjectFactory {
        ValidatableObject<T> GetValidatableObject<T>();
    }
}
