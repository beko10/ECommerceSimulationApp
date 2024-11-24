using ECommerceSimulationApp.BusinessLayer.BusinessRules.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;

namespace ECommerceSimulationApp.BusinessLayer.BusinessRules.Concrete;

public class EmployeeBusinessRules(IUnitOfWork unitOfWork) : IEmployeeBusinessRules
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IResult> EnsurePhoneNumberIsUnique(string customerPhoneNumerUniqe)
    {
        var existingEmployee = await _unitOfWork.EmployeeRepository.GetAsync(e => e.Phone == customerPhoneNumerUniqe);
        if(existingEmployee != null)
        {
            return new ErrorResult(ConstantsMessages.EmployeeMessages.EmployeeBusinessRuleError, new BusinessRuleException(ConstantsMessages.EmployeeMessages.EmployeePhoneAlreadyExists));
        }
        return new SuccessResult(ConstantsMessages.EmployeeMessages.EmployeeBusinessRuleSuccess);
    }
}
