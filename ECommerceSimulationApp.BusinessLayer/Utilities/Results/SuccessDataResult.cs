namespace ECommerceSimulationApp.BusinessLayer.Utilities.Results;

public class SuccessDataResult<T>:DataResult<T>
{

    public SuccessDataResult(T data):base(data,true,string.Empty)
    {
        
    }
    public SuccessDataResult(string messaga):base(default,true,messaga)
    {
        
    }
    public SuccessDataResult(T data,string messaga):base(data,true,messaga)
    {
        
    }
    public SuccessDataResult():base(default,true)
    {
        
    }
}
