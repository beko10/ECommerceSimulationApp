namespace ECommerceSimulationApp.BusinessLayer.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message, Exception? exception = null) : base(false, message, exception)
    {

    }
    public ErrorResult(string message) : base(false, message)
    {

    }
    public ErrorResult() : base(false)
    {
    }

    public void ThrowIfExceptionExists()
    {
        if (Exception != null)
        {
            throw Exception;
        }
    }
}
