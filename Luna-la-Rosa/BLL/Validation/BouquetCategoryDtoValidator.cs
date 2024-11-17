using BLL.DTO.BouquetCategory;
using FluentValidation;

namespace BLL.Validation;

public class BouquetCategoryDtoValidator : AbstractValidator<BouquetCategoryDto>
{
    public BouquetCategoryDtoValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Bouquet category name is required");
    }
}