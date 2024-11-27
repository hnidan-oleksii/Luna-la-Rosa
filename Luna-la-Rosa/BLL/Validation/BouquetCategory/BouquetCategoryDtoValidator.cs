using BLL.DTO.BouquetCategory;
using FluentValidation;

namespace BLL.Validation.BouquetCategory;

public class BouquetCategoryDtoValidator : AbstractValidator<BouquetCategoryDto>
{
    public BouquetCategoryDtoValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category name is required")
            .Length(1, 255).WithMessage("Category name length must be between 1 and 255 characters");
    }
}