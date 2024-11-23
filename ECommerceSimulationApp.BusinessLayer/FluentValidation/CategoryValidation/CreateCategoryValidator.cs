using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using FluentValidation;

namespace ECommerceSimulationApp.BusinessLayer.FluentValidation.CategoryValidation;

public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("Kategori alanı boş geçilemez.")
                .MinimumLength(5).WithMessage("Kategori adı minimum 5 karakter olmadılıdır.")
                .MaximumLength(25).WithMessage("Kategori adı maximum 25 karakter olmadılıdır.")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

        RuleFor(c => c.Description)
                        .NotEmpty().WithMessage("Kategori Açıklama alanı boş geçilemez.")
                        .MinimumLength(10).WithMessage("Kategori açıklaması en az 10 karakter olmalıdır")
                        .MaximumLength(25).WithMessage("Kategori açıklaması 25 karakterden fazla olmaz")
                        .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");
    }
}
