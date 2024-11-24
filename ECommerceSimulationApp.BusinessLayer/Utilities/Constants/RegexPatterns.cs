namespace ECommerceSimulationApp.BusinessLayer.Utilities.Constants;

public static class RegexPatterns
{
    public const string NamePattern = @"^[a-zA-ZÇçĞğİıÖöŞşÜü\s]+$";

    public const string PhonePattern = @"^\+?\d{10,15}$";

    public const string CityAndCountryPattern = @"^[a-zA-ZÇçĞğİıÖöŞşÜü\s]+$";
}

