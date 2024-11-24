using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.CustomerDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class CustomerManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCustomerDto> createValidator, IValidator<UpdateCustomerDto> updateValidator) : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateCustomerDto> _createValidator = createValidator;
    private readonly IValidator<UpdateCustomerDto> _updateValidator = updateValidator;

    public async Task<IDataResult<IEnumerable<GetAllCustomerDto>>> GetAll(bool track = true)
    {
        try
        {
            var customerList = await _unitOfWork.CustomerRepository.GetAll(null, false).ToListAsync();
            if (!customerList.Any())
            {
                return new ErrorDataResult<IEnumerable<GetAllCustomerDto>>(null, ConstantsMessages.CustomerMessages.CustomersNotFound);
            }
            var customerListMapping = _mapper.Map<IEnumerable<GetAllCustomerDto>>(customerList);
            return new SuccessDataResult<IEnumerable<GetAllCustomerDto>>(customerListMapping, ConstantsMessages.CustomerMessages.CustomersListed);
        }
        catch (Exception ex)
        {
            throw new Exception($"{ConstantsMessages.CustomerMessages.UnexpectedError} : {ex.Message}");
        }
    }

    public async Task<IDataResult<GetByIdCustomerDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(id, false);
            if (hasCustomer is null)
            {
                return new ErrorDataResult<GetByIdCustomerDto>(null, ConstantsMessages.CustomerMessages.CustomerNotFound);
            }
            var hasCustomersMapping = _mapper.Map<GetByIdCustomerDto>(hasCustomer);
            return new SuccessDataResult<GetByIdCustomerDto>(hasCustomersMapping, ConstantsMessages.CustomerMessages.CustomerFound);
        }
        catch (Exception ex)
        {

            throw new Exception($"{ConstantsMessages.CustomerMessages.UnexpectedError} : {ex.Message}");
        }
    }
    public async Task<IResult> CreateAsync(CreateCustomerDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var businessRuleIsCustomerPhoneNumerUniqeCheck = await IsCustomerPhoneNumerUniqe(entity.Phone);

            if (!businessRuleIsCustomerPhoneNumerUniqeCheck.IsSuccess)
            {
                throw new BusinessRuleException(businessRuleIsCustomerPhoneNumerUniqeCheck.Message);
            }

            var createCustomerDtoMapping = _mapper.Map<Customer>(entity);
            await _unitOfWork.CustomerRepository.CreateAsync(createCustomerDtoMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result < 0)
            {
                return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerCreateError);
            }
            return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerCreated);
        }
        catch (BusinessRuleException ex)
        {
            throw new BusinessRuleException($"{ConstantsMessages.CustomerMessages.CustomerBusinessRuleError}:{ex.Message}");
        }
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException($"{ConstantsMessages.CustomerMessages.TransactionError} : {ex.Message}");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ConstantsMessages.CustomerMessages.UnexpectedError} : {ex.Message}");
        }
    }

    public async Task<IResult> Remove(DeleteCustomerDto entity)
    {
        try
        {
            var hasCategory = await _unitOfWork.CustomerRepository.GetByIdAsync(entity.Id, false);
            if (hasCategory != null)
            {
                return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerNotFound);
            }
            
            _mapper.Map(entity, hasCategory);
            _unitOfWork.CustomerRepository.Remove(hasCategory!);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerDeleteError);
            }
            return new SuccessResult(ConstantsMessages.CustomerMessages.CustomerDeleted);
        }
        catch (Exception ex)
        {
            throw new Exception($"{ConstantsMessages.CustomerMessages.UnexpectedError} : {ex.Message}");
        }
    }

    public async Task<IResult> Update(UpdateCustomerDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var hasCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(entity.Id);
            if (hasCustomer != null)
            {
                return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerNotFound);
            }
            _mapper.Map(entity, hasCustomer);
            _unitOfWork.CustomerRepository.Update(hasCustomer);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerUpdateError);
            }
            return new SuccessResult(ConstantsMessages.CustomerMessages.CustomerUpdated);
        }
        catch (Exception ex)
        {

            throw new Exception($"{ConstantsMessages.CustomerMessages.TransactionError} : {ex.Message}");
        }
    }

    //Business(İş) Kuralları
    private async Task<IResult> IsCustomerPhoneNumerUniqe(string phoneNumber)
    {
        var result = await _unitOfWork.CustomerRepository.GetAsync(c => c.Phone == phoneNumber);
        if (result != null)
        {
            return new ErrorResult(ConstantsMessages.CustomerMessages.CustomerBusinessRulePhoneNumberError);
        }
        return new SuccessResult(ConstantsMessages.CustomerMessages.CustomerBusinessRuleSuccess);
    }


}
