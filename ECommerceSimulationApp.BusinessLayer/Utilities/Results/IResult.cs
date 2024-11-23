namespace ECommerceSimulationApp.BusinessLayer.Utilities.Results;

public interface IResult
{
    public string Message { get; }
    public bool IsSuccess { get; }
    public Exception Exception { get; }
}
