using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Constants;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryDto> _createValidator;
    private readonly IValidator<UpdateCategoryDto> _updateValidator;

    public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCategoryDto> createValidator, IValidator<UpdateCategoryDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<IDataResult<IEnumerable<GetAllCategoryDto>>> GetAll(bool track = true)
    {
        var categoryList = await _unitOfWork.CategoryRepository.GetAll(null, false).ToListAsync();
        if (!categoryList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllCategoryDto>>(ConstantsMessages.CategoryMessages.CategoriesNotFound);
        }

        var CategoryListMapping = _mapper.Map<IEnumerable<GetAllCategoryDto>>(categoryList);
        return new SuccessDataResult<IEnumerable<GetAllCategoryDto>>(CategoryListMapping, ConstantsMessages.CategoryMessages.CategoriesListed);
    }

    public async Task<IDataResult<GetByIdCategoryDto>> GetByIdAsync(string id, bool track = true)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id, false);
        if (category == null)
        {
            return new ErrorDataResult<GetByIdCategoryDto>(ConstantsMessages.CategoryMessages.CategoryNotFound);
        }

        var categoryMapping = _mapper.Map<GetByIdCategoryDto>(category);
        return new SuccessDataResult<GetByIdCategoryDto>(categoryMapping, ConstantsMessages.CategoryMessages.CategoryFound);
    }

    public async Task<IResult> CreateAsync(CreateCategoryDto entity)
    {
        var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);

        try
        {
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var categoryNameUniqueCheck = await IsCategoryNameUnique(entity.CategoryName!);
            if (!categoryNameUniqueCheck.IsSuccess)
            {
                return categoryNameUniqueCheck;
            }

            var createCategoryDtoMapping = _mapper.Map<Category>(entity);
            await _unitOfWork.CategoryRepository.CreateAsync(createCategoryDtoMapping);
            var result = await _unitOfWork.CommitAsync();

            if (result > 0)
            {
                return new SuccessResult(ConstantsMessages.CategoryMessages.CategoryCreated);
            }

            return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryCreateError);
        }
        catch (BusinessRuleException ex)
        {
            return new ErrorResult($"{ConstantsMessages.CategoryMessages.CategoryBusinessRuleError}: {ex.Message}");
        }
        catch (DbUpdateException ex)
        {
            return new ErrorResult($"{ConstantsMessages.CategoryMessages.TransactionError}: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new ErrorResult($"{ConstantsMessages.CategoryMessages.UnexpectedError}: {ex.Message}");
        }
    }

    public async Task<IResult> Remove(DeleteCategoryDto entity)
    {
        try
        {
            var hasDeletedCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(entity.Id!, false);
            if (hasDeletedCategory != null)
            {
                _unitOfWork.CategoryRepository.Remove(hasDeletedCategory);
                var result = await _unitOfWork.CommitAsync();

                if (result > 0)
                {
                    return new SuccessResult(ConstantsMessages.CategoryMessages.CategoryDeleted);
                }

                return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryDeleteError);
            }

            return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryNotFound);
        }
        catch (Exception ex)
        {
            return new ErrorResult($"{ConstantsMessages.CategoryMessages.UnexpectedError}: {ex.Message}");
        }
    }

    public async Task<IResult> Update(UpdateCategoryDto entity)
    {
        try
        {
            var validationResult = await ValidationHelper.ValidateWithFluent(_updateValidator, entity);

            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var hasUpdatedCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(entity.Id!, false);
            if (hasUpdatedCategory == null)
            {
                return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryNotFound);
            }

            _mapper.Map(entity, hasUpdatedCategory);
            _unitOfWork.CategoryRepository.Update(hasUpdatedCategory);
            var result = await _unitOfWork.CommitAsync();

            if (result > 0)
            {
                return new SuccessResult(ConstantsMessages.CategoryMessages.CategoryUpdated);
            }

            return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryUpdateError);
        }
        catch (Exception ex)
        {
            return new ErrorResult($"{ConstantsMessages.CategoryMessages.UnexpectedError}: {ex.Message}");
        }
    }

    // Business (İş) Kuralları
    private async Task<IResult> IsCategoryNameUnique(string categoryName)
    {
        var result = await _unitOfWork.CategoryRepository.Where(c => c.CategoryName!.ToLower() == categoryName.ToLower(), false).FirstOrDefaultAsync();
        if (result is not null)
        {
            return new ErrorResult(ConstantsMessages.CategoryMessages.CategoryNameExists);
        }

        return new SuccessResult();
    }
}
