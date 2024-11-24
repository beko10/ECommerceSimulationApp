using FluentValidation;
using ECommerceSimulationApp.EntityLayer.Dto.SupplierDto;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.SupplierValidation
{
    public class CreateSupplierDtoValidation : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidation()
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
}
