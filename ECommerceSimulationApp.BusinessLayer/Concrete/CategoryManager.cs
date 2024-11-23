using AutoMapper;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Exceptions.ExceptionTypes;
using ECommerceSimulationApp.BusinessLayer.Utilities.Helper;
using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using ECommerceSimulationApp.EntityLayer.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryDto> _createValidator;
    public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IDataResult<IEnumerable<GetAllCategoryDto>>> GetAll(bool track = true)
    {
        var categoryList = await _unitOfWork.CategoryRepository.GetAll(null,false).ToListAsync();
        if (!categoryList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllCategoryDto>>();
        } 
        var CategoryListMapping = _mapper.Map<IEnumerable<GetAllCategoryDto>>(categoryList);
        return new SuccessDataResult<IEnumerable<GetAllCategoryDto>>(CategoryListMapping);
    }

    public async Task<IDataResult<GetByIdCategoryDto>> GetByIdAsync(string id, bool track = true)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id,false);
        if(category == null)
        {
            return new ErrorDataResult<GetByIdCategoryDto>();
        }
        var categoryMapping = _mapper.Map<GetByIdCategoryDto>(category);
        return new SuccessDataResult<GetByIdCategoryDto>(categoryMapping);
    }
    public async Task<IResult> CreateAsync(CreateCategoryDto entity)
    {
        //var validationResult = await ValidationHelper.ValidateWithFluent<CreateCategoryDto>(_createValidator, entity);
        var validationResult = await ValidationHelper.ValidateWithFluent(_createValidator, entity);
        try
        {
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var createCategoryDtoMapping = _mapper.Map<Category>(entity);
            await _unitOfWork.CategoryRepository.CreateAsync(createCategoryDtoMapping);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
            {
                return new SuccessResult("İşlem Başarılı");
            }
            return new ErrorResult("Bir şeyler ters gitti");
        }
        catch(BusinessRuleException ex)
        {
            throw new BusinessRuleException(ex.Message);
        }
        catch(DbUpdateException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public IResult Remove(DeleteCategoryDto entity)
    {
        throw new NotImplementedException();
    }

    public IResult Update(UpdateCategoryDto entity)
    {
        throw new NotImplementedException();
    }

    //Business(İş) kuralları
    private async Task<IResult> IsCategoryNameUnique(string categoryName)
    {
        var result = await _unitOfWork.CategoryRepository.Where(c => c.CategoryName!.ToLower() == categoryName, false).FirstOrDefaultAsync();
        if(result is not null)
        {
            return new ErrorResult("Bu kategori adında zaten kayıtlı kategori var");
        }
        return new SuccessResult();
    }
}
