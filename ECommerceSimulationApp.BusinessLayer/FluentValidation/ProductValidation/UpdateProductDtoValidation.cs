using ECommerceSimulationApp.EntityLayer.Dto.ProductDto;
using FluentValidation;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.ProductValidation;

public class UpdateProductDtoValidation : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidation()
    {
        // ProductName doğrulama
        RuleFor(product => product.ProductName)
            .NotEmpty()
            .WithMessage(ProductMessages.ProductNameRequired)
            .Length(2, 100)
            .WithMessage(ProductMessages.ProductNameLength);

        // UnitPrice doğrulama
        RuleFor(product => product.UnitPrice)
            .GreaterThan(0)
            .WithMessage(ProductMessages.UnitPriceGreaterThanZero)
            .LessThanOrEqualTo(10000)
            .WithMessage(ProductMessages.UnitPriceTooHigh);

        // UnitsInStock doğrulama
        RuleFor(product => product.UnitsInStock)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ProductMessages.UnitsInStockMustBePositive);

        // CategoryName doğrulama
        RuleFor(product => product.CategoryName)
            .NotEmpty()
            .WithMessage(ProductMessages.CategoryNameRequired)
            .Length(2, 50)
            .WithMessage(ProductMessages.CategoryNameLength);

        // SupplierName doğrulama
        RuleFor(product => product.SupplierName)
            .NotEmpty()
            .WithMessage(ProductMessages.SupplierNameRequired)
            .Length(2, 50)
            .WithMessage(ProductMessages.SupplierNameLength);
    }
}
