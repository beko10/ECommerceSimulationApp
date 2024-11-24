namespace ECommerceSimulationApp.BusinessLayer.Utilities.Constants
{
    public static class RegexPatterns
    {
        public const string NamePattern = @"^[a-zA-ZÇçĞğİıÖöŞşÜü\s]+$";
        public const string PhonePattern = @"^\+?[0-9\s\-]{7,15}$";
        public const string CityAndCountryPattern = @"^[a-zA-ZÇçĞğİıÖöŞşÜü\s]+$";
    }
}
