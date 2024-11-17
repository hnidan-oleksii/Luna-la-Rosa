using BLL.DTO.BouquetCategoryBouquet;
using FluentValidation;

namespace BLL.Validation;

public class BouquetCategoryBouquetDtoValidator : AbstractValidator<BouquetCategoryBouquetDto>
{
    public BouquetCategoryBouquetDtoValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("BouquetCategoryId is required.");
    }
}