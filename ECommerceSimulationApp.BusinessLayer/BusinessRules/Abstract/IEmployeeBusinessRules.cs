using ECommerceSimulationApp.BusinessLayer.Utilities.Results;

namespace ECommerceSimulationApp.BusinessLayer.BusinessRules.Abstract;

public interface IEmployeeBusinessRules
{
    Task<IResult>EnsurePhoneNumberIsUnique(string customerPhoneNumerUniqe);
}
