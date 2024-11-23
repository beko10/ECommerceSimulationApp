using ECommerceSimulationApp.BusinessLayer.Utilities.Results;

namespace ECommerceSimulationApp.BusinessLayer.Utilities;

public class Result : IResult
{
    public string Message { get; } = string.Empty;

    public bool IsSuccess { get; }

    public Exception Exception { get; }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    public Result(bool isSuccess, string message) : this(isSuccess)
    {
        Message = message;
    }

    public Result(bool isSuccess, string message, Exception? exception = null) : this(isSuccess, message)
    {
        Exception = exception;
    }
}
