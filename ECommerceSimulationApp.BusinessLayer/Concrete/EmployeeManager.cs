using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.BusinessRules.Abstract;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateEmployeeDto> createValidator, IValidator<UpdateEmployeeDto> updateValidator) : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateEmployeeDto> _createValidator = createValidator;
    private readonly IValidator<UpdateEmployeeDto> _updateValidator = updateValidator;  
    private readonly IEmployeeBusinessRules _employeeBusinessRules;
    public async Task<IDataResult<IEnumerable<GetAllEmployeeDto>>> GetAll(bool track = true)
    {
        try
        {
            var employeeList = await _unitOfWork.EmployeeRepository.GetAll(null, track).ToListAsync();
            if (!employeeList.Any())
            {
                return new ErrorDataResult<IEnumerable<GetAllEmployeeDto>>(ConstantsMessages.EmployeeMessages.EmployeesNotFound);
            }
            var employeeListMapping = _mapper.Map<IEnumerable<GetAllEmployeeDto>>(employeeList);
            return new SuccessDataResult<IEnumerable<GetAllEmployeeDto>>(employeeListMapping, ConstantsMessages.EmployeeMessages.EmployeesListed);
        }
        catch (Exception ex)
        {

            throw new Exception($"{ConstantsMessages.EmployeeMessages.UnexpectedError} : {ex.Message}");
        }
    }

    public async Task<IDataResult<GetByIdEmployeeDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id, track);
            if (hasEmployee is null)
            {
                return new ErrorDataResult<GetByIdEmployeeDto>(ConstantsMessages.EmployeeMessages.EmployeeNotFound);
            }
            var hasEmployeeMapping = _mapper.Map<GetByIdEmployeeDto>(hasEmployee);
            return new SuccessDataResult<GetByIdEmployeeDto>(ConstantsMessages.EmployeeMessages.EmployeeFound);
        }
        catch (Exception ex)
        {

            throw new Exception($"{ConstantsMessages.EmployeeMessages.UnexpectedError} : {ex.Message}");
        }
    }
    public async Task<IResult> CreateAsync(CreateEmployeeDto entity)
    {
        try
        {
            var valdationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
            if (!valdationResult.IsSuccess)
            {
                return valdationResult;
            }
            var employeeBusinesRuleEnsurmePhoneNumberCheck = await _employeeBusinessRules.EnsurePhoneNumberIsUnique(entity.Phone);
            if (!employeeBusinesRuleEnsurmePhoneNumberCheck.IsSuccess)
            {
                throw employeeBusinesRuleEnsurmePhoneNumberCheck.Exception;
            }
            var createEmployeeMapping = _mapper.Map<Employee>(entity);
            await _unitOfWork.EmployeeRepository.CreateAsync(createEmployeeMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.EmployeeMessages.EmployeeCreateError, new DbUpdateException(ConstantsMessages.EmployeeMessages.TransactionError));
            }
            return new SuccessResult(ConstantsMessages.EmployeeMessages.EmployeeCreated);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);

        }
    }

    public async Task<IResult> Remove(DeleteEmployeeDto entity)
    {
        try
        {
            var hasEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(entity.Id, false);
            if (hasEmployee == null)
            {
                return new ErrorResult(ConstantsMessages.EmployeeMessages.EmployeeNotFound);
            }
            var hasEmployeeMapping = _mapper.Map<Employee>(entity);
            _unitOfWork.EmployeeRepository.Remove(hasEmployeeMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.EmployeeMessages.EmployeeDeleteError);
            }
            return new SuccessResult(ConstantsMessages.EmployeeMessages.EmployeeDeleted);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public async Task<IResult> Update(UpdateEmployeeDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var hasEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(entity.Id, false);
            if (hasEmployee == null)
            {
                return new ErrorResult(ConstantsMessages.EmployeeMessages.EmployeeNotFound);
            }

            if (hasEmployee.Phone != entity.Phone)
            {
                var phoneNumberCheck = await _employeeBusinessRules.EnsurePhoneNumberIsUnique(entity.Phone);
                if (!phoneNumberCheck.IsSuccess)
                {
                    throw phoneNumberCheck.Exception;
                }
            }

            var updateEmployeeMapping = _mapper.Map<Employee>(entity);
            _unitOfWork.EmployeeRepository.Update(updateEmployeeMapping);
            var result = await _unitOfWork.CommitAsync();

            if (result <= 0)
            {
                return new ErrorResult(
                    ConstantsMessages.EmployeeMessages.EmployeeUpdateError);
            }

            return new SuccessResult(ConstantsMessages.EmployeeMessages.EmployeeUpdated);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception($"Veritabanı güncelleme hatası: {ex.Message}");
        }
        catch (AutoMapperMappingException ex)
        {
            throw new Exception($"Mapping hatası: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ConstantsMessages.EmployeeMessages.UnexpectedError} : {ex.Message}");
        }
    }
}
