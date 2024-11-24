using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDto;
using FluentValidation;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.OrderValidation;

public class UpdateOrderDtoValidation:AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidation()
    {
        // Sipariş tarihi: Geçerli bir tarih olmalı (örneğin, 1 yıl sonrası geçersiz).
        RuleFor(order => order.OrderDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage(ConstantsMessages.OrderMessages.OrderDateTooEarly)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(1)))
            .WithMessage(ConstantsMessages.OrderMessages.OrderDateTooLate);

        // Teslimat adresi doğrulama
        RuleFor(order => order.ShipAddress)
            .NotEmpty()
            .WithMessage(ConstantsMessages.OrderMessages.ShipAddressRequired)
            .Length(5, 250)
            .WithMessage(ConstantsMessages.OrderMessages.ShipAddressLength);

        // Şehir adı doğrulama
        RuleFor(order => order.ShipCity)
            .NotEmpty()
            .WithMessage(ConstantsMessages.OrderMessages.ShipCityRequired)
            .Length(2, 50)
            .WithMessage(ConstantsMessages.OrderMessages.ShipCityLength)
            .Matches(RegexPatterns.CityAndCountryPattern)
            .WithMessage(ConstantsMessages.OrderMessages.ShipCityInvalid);

        // Ülke adı doğrulama
        RuleFor(order => order.ShipCountry)
            .NotEmpty()
            .WithMessage(ConstantsMessages.OrderMessages.ShipCountryRequired)
            .Length(2, 50)
            .WithMessage(ConstantsMessages.OrderMessages.ShipCountryLength)
            .Matches(RegexPatterns.CityAndCountryPattern)
            .WithMessage(ConstantsMessages.OrderMessages.ShipCountryInvalid);
    }
}
