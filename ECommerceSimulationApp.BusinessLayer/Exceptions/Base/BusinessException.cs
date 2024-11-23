﻿namespace ECommerceSimulationApp.BusinessLayer.Exceptions.Base;

public abstract class BusinessException : Exception
{
    protected BusinessException(string message):base(message)
    {   
    }
    protected BusinessException(string message,Exception innerException):base(message, innerException) 
    {
    }
}