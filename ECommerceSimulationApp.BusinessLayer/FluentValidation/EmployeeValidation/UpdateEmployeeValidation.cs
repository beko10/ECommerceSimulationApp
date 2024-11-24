using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;
using FluentValidation;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.EmployeeValidation;

public class UpdateEmployeeValidation:AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeValidation()
    {
        // Name
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(EmployeeMessages.NameRequired)
            .Length(2, 50).WithMessage(EmployeeMessages.NameLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(EmployeeMessages.NameRegex);

        // SurName
        RuleFor(x => x.SurName)
            .NotEmpty().WithMessage(EmployeeMessages.SurNameRequired)
            .Length(2, 50).WithMessage(EmployeeMessages.SurNameLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(EmployeeMessages.SurNameRegex);

        // Country
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage(EmployeeMessages.CountryRequired)
            .Length(2, 50).WithMessage(EmployeeMessages.CountryLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(EmployeeMessages.CountryRegex);

        // City
        RuleFor(x => x.City)
            .NotEmpty().WithMessage(EmployeeMessages.CityRequired)
            .Length(2, 50).WithMessage(EmployeeMessages.CityLength)
            .Matches(RegexPatterns.NamePattern).WithMessage(EmployeeMessages.CityRegex);

        // Phone
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(EmployeeMessages.PhoneRequired)
            .Length(10, 15).WithMessage(EmployeeMessages.PhoneLength)
            .Matches(RegexPatterns.PhonePattern).WithMessage(EmployeeMessages.PhoneRegex);
    }
}
