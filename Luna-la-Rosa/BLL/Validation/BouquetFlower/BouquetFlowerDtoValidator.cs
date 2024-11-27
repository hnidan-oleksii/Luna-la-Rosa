using BLL.DTO.BouquetFlower;
using FluentValidation;

namespace BLL.Validation.BouquetFlower;

public class BouquetFlowerDtoValidator : AbstractValidator<BouquetFlowerDto>
{
    public BouquetFlowerDtoValidator()
    {
        RuleFor(x => x.FlowerId)
            .NotEmpty().WithMessage("FlowerId id required")
            .GreaterThan(0).WithMessage("FlowerId must be greater than 0");
        RuleFor(x => x.BouquetId)
            .NotEmpty().WithMessage("BouquetId id required")
            .GreaterThan(0).WithMessage("BouquetId must be greater than 0");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}