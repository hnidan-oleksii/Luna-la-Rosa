using BLL.DTO.BouquetCategoryBouquet;
using FluentValidation;

namespace BLL.Validation.BouquetCategory;

public class BouquetCategoryBouquetDtoValidator : AbstractValidator<BouquetCategoryBouquetDto>
{
    public BouquetCategoryBouquetDtoValidator()
    {
        RuleFor(x => x.BouquetId)
            .NotEmpty().WithMessage("BouquetId is required")
            .GreaterThan(0).WithMessage("BouquetId must be greater than 0");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required")
            .GreaterThan(0).WithMessage("CategoryId must be greater than 0");
    }
}