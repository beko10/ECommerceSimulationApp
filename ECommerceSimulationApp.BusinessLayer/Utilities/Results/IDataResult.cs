namespace ECommerceSimulationApp.BusinessLayer.Utilities.Results;

public interface IDataResult<T> : IResult
{
    public T Data { get; }
}
