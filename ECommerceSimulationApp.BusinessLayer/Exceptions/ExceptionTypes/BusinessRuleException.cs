using ECommerceSimulationApp.BusinessLayer.Exceptions.Base;

namespace ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;

public class BusinessRuleException : BusinessException
{

    public BusinessRuleException(string message) : base(message)
    {
    }
}
