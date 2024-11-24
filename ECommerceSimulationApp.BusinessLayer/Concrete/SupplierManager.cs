using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.SupplierDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class SupplierManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSupplierDto> createValidator, IValidator<UpdateSupplierDto> updateValidator) : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateSupplierDto> _createValidator = createValidator;
    private readonly IValidator<UpdateSupplierDto> _updateValidator = updateValidator;

    public async Task<IDataResult<IEnumerable<GetAllSupplierDto>>> GetAll(bool track = true)
    {
        try
        {
            var supplierList = await _unitOfWork.SupplierRepository.GetAll(null, track).ToListAsync();
            if (supplierList is null)
            {
                return new ErrorDataResult<IEnumerable<GetAllSupplierDto>>(null, ConstantsMessages.SupplierMessages.SuppliersNotFound);
            }
            var supplierListMapping = _mapper.Map<IEnumerable<GetAllSupplierDto>>(supplierList);
            return new SuccessDataResult<IEnumerable<GetAllSupplierDto>>(supplierListMapping, ConstantsMessages.SupplierMessages.SuppliersListed);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IDataResult<GetByIdSupplierDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasSupplier = await _unitOfWork.SupplierRepository.GetByIdAsync(id, track);
            if (hasSupplier is null)
            {
                return new ErrorDataResult<GetByIdSupplierDto>(null, ConstantsMessages.SupplierMessages.SupplierNotFound);
            }
            var hasSupplierMapping = _mapper.Map<GetByIdSupplierDto>(hasSupplier);
            return new SuccessDataResult<GetByIdSupplierDto>(hasSupplierMapping, ConstantsMessages.SupplierMessages.SupplierFound);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> CreateAsync(CreateSupplierDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var createdSupplier = _mapper.Map<Supplier>(entity);
            await _unitOfWork.SupplierRepository.CreateAsync(createdSupplier);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.SupplierMessages.SupplierCreateError);
            }
            return new SuccessResult(ConstantsMessages.SupplierMessages.SupplierCreated);
        }
        catch (BusinessRuleException ex)
        {
            throw new BusinessRuleException($"{ConstantsMessages.SupplierMessages.ValidationError} : {ex.Message}");
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Remove(DeleteSupplierDto entity)
    {
        try
        {
            var hasDeletedSupplier = await _unitOfWork.SupplierRepository.GetByIdAsync(entity.Id,
                false);
            if (hasDeletedSupplier is null)
            {
                return new ErrorResult(ConstantsMessages.SupplierMessages.SupplierNotFound);
            }
            var deletetedSupplier = _mapper.Map<Supplier>(entity);
            _unitOfWork.SupplierRepository.Remove(deletetedSupplier);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.SupplierMessages.SupplierDeleteError);
            }
            return new SuccessResult(ConstantsMessages.SupplierMessages.SupplierDeleted);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Update(UpdateSupplierDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var hasSupplier = await _unitOfWork.SupplierRepository.GetByIdAsync(entity.Id, false);
            if (hasSupplier is null)
            {
                return new ErrorResult(ConstantsMessages.SupplierMessages.SupplierNotFound);
            }
            var updatedSupplier = _mapper.Map<Supplier>(entity);
            _unitOfWork.SupplierRepository.Update(updatedSupplier);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.SupplierMessages.SupplierUpdateError);
            }
            return new SuccessResult(ConstantsMessages.SupplierMessages.SupplierUpdated);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
