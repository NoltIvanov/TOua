using System.Text.RegularExpressions;
using TOua.Helpers.Validations.Contracts;

namespace TOua.Helpers.Validations.ValidationRules {
    public class SpecificSymbolsRule<T> : IValidationRule<T> {

        public const string ALPHANUMERIC_SYMBOLS = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";

        public string ValidationMessage { get; set; }

        public bool Check(T value) {
            if (value == null) return false;

            var str = value as string;

            var regex = new Regex(ALPHANUMERIC_SYMBOLS);

            bool res = regex.IsMatch(str);

            return !res;
        }
    }
}
