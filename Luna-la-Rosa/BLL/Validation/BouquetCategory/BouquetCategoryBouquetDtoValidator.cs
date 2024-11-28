using BLL.DTO.BouquetCategoryBouquet;
using FluentValidation;

namespace BLL.Validation.BouquetCategory;

public class BouquetCategoryBouquetDtoValidator : AbstractValidator<BouquetCategoryBouquetDto>
{
    public BouquetCategoryBouquetDtoValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("BouquetCategoryId is required.");
    }
}