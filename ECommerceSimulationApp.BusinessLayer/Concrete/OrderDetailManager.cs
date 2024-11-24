using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDetailDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class OrderDetailManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateOrderDetailDto> createValidator, IValidator<UpdateOrderDetailDto> updateValidator) : IOrderDetailsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateOrderDetailDto> _createValidator = createValidator;
    private readonly IValidator<UpdateOrderDetailDto> _updateValidator = updateValidator;

    public async Task<IDataResult<IEnumerable<GetAllOrderDetailDto>>> GetAll(bool track = true)
    {
        try
        {
            var orderDetailList = await _unitOfWork.OrderDetailRepository.GetAll(null, track).ToListAsync();
            if (!orderDetailList.Any())
            {
                return new ErrorDataResult<IEnumerable<GetAllOrderDetailDto>>(null, ConstantsMessages.OrderDetailMessages.OrderDetailsNotFound);
            }
            var orderDetailListMappping = _mapper.Map<IEnumerable<GetAllOrderDetailDto>>(orderDetailList);
            return new SuccessDataResult<IEnumerable<GetAllOrderDetailDto>>(orderDetailListMappping, ConstantsMessages.OrderDetailMessages.OrderDetailsListed);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IDataResult<GetByIdOrderDetailDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasOrderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id, track);
            if (hasOrderDetail is null)
            {
                return new ErrorDataResult<GetByIdOrderDetailDto>(null, ConstantsMessages.OrderDetailMessages.OrderDetailNotFound);
            }
            var hasOrderDetailMapping = _mapper.Map<GetByIdOrderDetailDto>(hasOrderDetail);
            return new SuccessDataResult<GetByIdOrderDetailDto>(hasOrderDetailMapping);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IResult> CreateAsync(CreateOrderDetailDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var creataOrderDetailDtoMapping = _mapper.Map<OrderDetail>(entity);
            await _unitOfWork.OrderDetailRepository.CreateAsync(creataOrderDetailDtoMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderDetailMessages.OrderDetailCreateError);
            }
            return new SuccessResult(ConstantsMessages.OrderDetailMessages.OrderDetailCreated);
        }
        catch (ValidationException ex)
        {
            throw new ValidationException(ex.Message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Remove(DeleteOrderDetailDto entity)
    {
        try
        {
            var hasDeletedOrderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(entity.Id);
            if (hasDeletedOrderDetail is null)
            {
                return new ErrorResult(ConstantsMessages.OrderDetailMessages.OrderDetailNotFound);
            }
            var updatedOrderDetail = _mapper.Map<OrderDetail>(entity);
            _unitOfWork.OrderDetailRepository.Remove(updatedOrderDetail);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderDetailMessages.OrderDetailDeleteError);
            }
            return new SuccessResult(ConstantsMessages.OrderDetailMessages.OrderDetailDeleted);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Update(UpdateOrderDetailDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var hasOrderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(entity.Id, false);
            if (hasOrderDetail is null)
            {
                return new ErrorResult(ConstantsMessages.OrderDetailMessages.OrderDetailNotFound);
            }
            var updatedOrderDetail = _mapper.Map<OrderDetail>(entity);
            _unitOfWork.OrderDetailRepository.Update(updatedOrderDetail);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.OrderDetailMessages.OrderDetailUpdateError);
            }
            return new SuccessResult(ConstantsMessages.OrderDetailMessages.OrderDetailUpdated);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
