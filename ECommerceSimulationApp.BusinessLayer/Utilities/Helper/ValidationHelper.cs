using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using FluentValidation;

namespace ECommerceSimulationApp.BusinessLayer.Utilities.Helper;

public static class ValidationHelper
{
    public static async Task<IResult> ValidateWithFluent<T>(IValidator<T> validator,T entity)
    {
        const string ValidationMessage = "Doğrulama işlemi başarılı";

        var validationResult = await validator.ValidateAsync(entity);   
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            return new ErrorResult(errors);
        }
        return new SuccessResult(ValidationMessage);
    }
}
