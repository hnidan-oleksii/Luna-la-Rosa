using BLL.DTO.CustomBouquet;
using FluentValidation;

namespace BLL.Validation.CustomBouquet;

public class CustomBouquetDtoValidator : AbstractValidator<CustomBouquetDto>
{
    public CustomBouquetDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
        RuleFor(x => x.TotalPrice)
            .NotEmpty().WithMessage("TotalPrice is required")
            .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        RuleFor(x => x.CustomBouquetFlowers)
            .NotEmpty().WithMessage("CustomBouquetFlowers must not be empty");
    }
}