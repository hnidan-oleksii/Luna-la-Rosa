using BLL.DTO.BouquetFlower;
using FluentValidation;

namespace BLL.Validation;

public class BouquetFlowerDtoValidator : AbstractValidator<BouquetFlowerDto>
{
    public BouquetFlowerDtoValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        RuleFor(x => x.FlowerId)
            .NotEmpty().WithMessage("Flower ID id required");
    }
}