using ECommerceSimulationApp.EntityLayer.Dto.OrderDetailDto;
using FluentValidation;
using static ECommerceSimulationApp.BusinessLayer.Utilities.Constants.ConstantsMessages;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.OrderDetailValidation
{
    public class CreateOrderDetailDtoValidation : AbstractValidator<CreateOrderDetailDto>
    {
        public CreateOrderDetailDtoValidation()
        {
            // Quantity doğrulama
            RuleFor(detail => detail.Quantity)
                .GreaterThan(0)
                .WithMessage(OrderDetailMessages.QuantityMustBeGreaterThanZero);

            // UnitPrice doğrulama
            RuleFor(detail => detail.UnitPrice)
                .GreaterThan(0)
                .WithMessage(OrderDetailMessages.UnitPriceMustBeGreaterThanZero)
                .LessThanOrEqualTo(10000)
                .WithMessage(OrderDetailMessages.UnitPriceTooHigh);
        }
    }
}
