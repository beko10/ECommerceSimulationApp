using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.FluentValidation.OrderValidation;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class OrderManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateOrderDto> createValidation, IValidator<UpdateOrderDto> updateValidator) : IOrderService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateOrderDto> _createValidation = createValidation;
    private readonly IValidator<UpdateOrderDto> _updateValidator = updateValidator;

    public async Task<IDataResult<IEnumerable<GetAllOrderDto>>> GetAll(bool track = true)
    {
        try
        {
            var orderList = await _unitOfWork.OrderRepository.GetAll(null, track).ToListAsync();
            if (orderList == null)
            {
                return new ErrorDataResult<IEnumerable<GetAllOrderDto>>(null, ConstantsMessages.OrderMessages.OrdersNotFound);
            }
            var orderListMapping = _mapper.Map<IEnumerable<GetAllOrderDto>>(orderList);
            return new SuccessDataResult<IEnumerable<GetAllOrderDto>>(orderListMapping, ConstantsMessages.OrderMessages.OrdersListed);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IDataResult<GetByIdOrderDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasOrder = await _unitOfWork.OrderRepository.GetByIdAsync(id, track);
            if (hasOrder == null)
            {
                return new ErrorDataResult<GetByIdOrderDto>(null, ConstantsMessages.OrderMessages.OrderNotFound);
            }
            var hasOrderMapping = _mapper.Map<GetByIdOrderDto>(hasOrder);
            return new SuccessDataResult<GetByIdOrderDto>(hasOrderMapping, ConstantsMessages.OrderMessages.OrderFound);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IResult> CreateAsync(CreateOrderDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_createValidation, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var createdOrderDtoMapping = _mapper.Map<Order>(entity);
            await _unitOfWork.OrderRepository.CreateAsync(createdOrderDtoMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderMessages.InvalidOperation);
            }
            return new SuccessResult(ConstantsMessages.OrderMessages.OrderCreated);
        }
        catch (BusinessRuleException ex)
        {
            throw new BusinessRuleException($"{ConstantsMessages.OrderMessages.OrderBusinessRuleError} : {ex.Message}");
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Remove(DeleteOrderDto entity)
    {
        try
        {
            var hasDeleteOrder = await _unitOfWork.OrderRepository.GetByIdAsync(entity.Id, false);
            if (hasDeleteOrder == null)
            {
                return new ErrorResult(ConstantsMessages.OrderMessages.OrderNotFound);
            }
            _unitOfWork.OrderRepository.Remove(hasDeleteOrder);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderMessages.OrderDeleteError);
            }
            return new SuccessResult(ConstantsMessages.OrderMessages.OrderDeleted);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Update(UpdateOrderDto entity)
    {
        try
        {
            var hasUpdatedOrder = await _unitOfWork.OrderRepository.GetByIdAsync(entity.Id);
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if(!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            _mapper.Map(entity,hasUpdatedOrder);
            _unitOfWork.OrderRepository.Update(hasUpdatedOrder);
            var result = await _unitOfWork.CommitAsync();   
            if(result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderMessages.OrderUpdateError);
            }
            return new SuccessResult(ConstantsMessages.OrderMessages.OrderUpdated);
        }
        catch(BusinessRuleException ex)
        {
            throw new BusinessRuleException($"{ConstantsMessages.OrderMessages.OrderBusinessRuleError} : {ex.Message}");
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
