using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.EntityLayer.Dto.SupplierDto;
using FluentValidation;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.SupplierValidation;

public class UpdateSupplierDtoValidation : AbstractValidator<UpdateSupplierDto>
{
    public UpdateSupplierDtoValidation()
    {
        RuleFor(supplier => supplier.CompanyName)
                .NotEmpty().WithMessage(SupplierMessages.CompanyNameRequired)
                .Length(2, 100).WithMessage(SupplierMessages.CompanyNameLength);

        RuleFor(supplier => supplier.ContactTitle)
            .NotEmpty().WithMessage(SupplierMessages.ContactTitleRequired)
            .Length(2, 50).WithMessage(SupplierMessages.ContactTitleLength);

        RuleFor(supplier => supplier.Country)
            .NotEmpty().WithMessage(SupplierMessages.CountryRequired);

        RuleFor(supplier => supplier.City)
            .NotEmpty().WithMessage(SupplierMessages.CityRequired);

        RuleFor(supplier => supplier.Phone)
            .NotEmpty().WithMessage(SupplierMessages.PhoneRequired)
            .Matches(RegexPatterns.PhonePattern).WithMessage(SupplierMessages.PhoneInvalid);
    }
}
