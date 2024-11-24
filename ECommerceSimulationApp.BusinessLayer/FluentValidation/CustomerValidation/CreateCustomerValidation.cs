using ECommerceSimulationApp.EntityLayer.Dto.CustomerDto;
using FluentValidation;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.CustomerValidation;

public class CreateCustomerValidation : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerValidation()
    {
        // CustomerName
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage(CustomerMessages.CustomerNameRequired)
            .Length(2, 50).WithMessage(CustomerMessages.CustomerNameLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(CustomerMessages.CustomerNameRegex);

        // Country
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage(CustomerMessages.CountryRequired)
            .Length(2, 50).WithMessage(CustomerMessages.CountryLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(CustomerMessages.CountryRegex);

        // City
        RuleFor(x => x.City)
            .NotEmpty().WithMessage(CustomerMessages.CityRequired)
            .Length(2, 50).WithMessage(CustomerMessages.CityLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(CustomerMessages.CityRegex);

        // Phone
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(CustomerMessages.PhoneRequired)
            .Matches(RegexPatterns.PhonePattern).WithMessage(CustomerMessages.PhoneRegex)
            .MaximumLength(15).WithMessage(CustomerMessages.PhoneMaxLength);
    }
}
