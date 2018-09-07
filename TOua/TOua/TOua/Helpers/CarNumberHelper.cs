namespace TOua.Helpers {
    public static class CarNumberHelper {
        public static string ValidateCarNumber(this string value) {
            return value.Replace(" ", "").ToUpper().Trim();
        }
    }
}
