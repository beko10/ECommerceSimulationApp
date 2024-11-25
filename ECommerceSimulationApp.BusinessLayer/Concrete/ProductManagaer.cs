using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.ProductDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class ProductManagaer(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductDto> createValidator, IValidator<UpdateProductDto> updateValidator) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateProductDto> _createValidator = createValidator;
    private readonly IValidator<UpdateProductDto> _updateValidator = updateValidator;

    public async Task<IDataResult<IEnumerable<GetAllProductDto>>> GetAll(bool track = true)
    {
        try
        {
            var productList = await _unitOfWork.ProductRepository.GetAll(null, track).ToListAsync();
            if (!productList.Any())
            {
                return new ErrorDataResult<IEnumerable<GetAllProductDto>>(null, ConstantsMessages.ProductMessages.ProductsNotFound);
            }
            var productListMapping = _mapper.Map<IEnumerable<GetAllProductDto>>(productList);
            return new SuccessDataResult<IEnumerable<GetAllProductDto>>(productListMapping, ConstantsMessages.ProductMessages.ProductsListed);

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IDataResult<GetByIdProductDto>> GetByIdAsync(string id, bool track = true)
    {
        try
        {
            var hasProduct = await _unitOfWork.ProductRepository.GetByIdAsync(id, track);
            if (hasProduct is null)
            {
                return new ErrorDataResult<GetByIdProductDto>(null, ConstantsMessages.ProductMessages.ProductNotFound);
            }
            var hasProductMapping = _mapper.Map<GetByIdProductDto>(hasProduct);
            return new SuccessDataResult<GetByIdProductDto>(hasProductMapping, ConstantsMessages.ProductMessages.ProductFound);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IResult> CreateAsync(CreateProductDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var createdProduct = _mapper.Map<Product>(entity);
            await _unitOfWork.ProductRepository.CreateAsync(createdProduct);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.ProductMessages.ProductCreateError);
            }
            return new SuccessResult(ConstantsMessages.ProductMessages.ProductCreated);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Remove(DeleteProductDto entity)
    {
        try
        {
            var hasProduct = await _unitOfWork.ProductRepository.GetByIdAsync(entity.Id, false);
            if (hasProduct == null)
            {
                return new ErrorResult(ConstantsMessages.ProductMessages.ProductNotFound);
            }
            var deletedProductMapping = _mapper.Map<Product>(hasProduct);
            _unitOfWork.ProductRepository.Remove(deletedProductMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.ProductMessages.ProductDeleteError);
            }
            return new SuccessResult(ConstantsMessages.ProductMessages.ProductDeleted);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IResult> Update(UpdateProductDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);
            if (!validationResult.IsSuccess)
            {
                throw validationResult.Exception;
            }
            var hasProduct = await _unitOfWork.ProductRepository.GetByIdAsync(entity.Id, false);
            if (hasProduct is null)
            {
                return new ErrorResult(ConstantsMessages.ProductMessages.ProductNotFound);
            }
            var updatedProductMapping = _mapper.Map<Product>(hasProduct);
            _unitOfWork.ProductRepository.Update(updatedProductMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result <= 0)
            {
                return new ErrorResult(ConstantsMessages.ProductMessages.ProductUpdateError);
            }
            return new SuccessResult(ConstantsMessages.ProductMessages.ProductUpdated);
        }
        catch (BusinessRuleException ex)
        {
            throw new BusinessRuleException($"{ConstantsMessages.ProductMessages.ProductBusinessRuleError} : {ex.Message}");
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IDataResult<IEnumerable<SearchResultProductDto>>> SearchProduct(string searchProductName, bool track = true)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(searchProductName))
            {
                return new ErrorDataResult<IEnumerable<SearchResultProductDto>>(null, "Arama yapmak için bir karakter girin");
            }
            var searchText = searchProductName.Trim().ToLowerInvariant();
            var searchProductListResult = await _unitOfWork.ProductRepository.Where(p => p.ProductName.ToLower().Contains(searchText), track).ToListAsync();
            if (!searchProductListResult.Any())
            {
                return new ErrorDataResult<IEnumerable<SearchResultProductDto>>(null, ConstantsMessages.ProductMessages.ProductsNotFound);
            }
            var searchProductListResultMapping = _mapper.Map<IEnumerable<SearchResultProductDto>>(searchProductListResult);
            return new SuccessDataResult<IEnumerable<SearchResultProductDto>>(searchProductListResultMapping, ConstantsMessages.ProductMessages.ProductsListed);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
