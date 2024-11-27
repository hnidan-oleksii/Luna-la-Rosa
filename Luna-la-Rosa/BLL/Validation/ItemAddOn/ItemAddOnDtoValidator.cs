using BLL.DTO.ItemAddOn;
using FluentValidation;

namespace BLL.Validation.ItemAddOn;

public class ItemAddOnDtoValidator : AbstractValidator<ItemAddOnDto>
{
    public ItemAddOnDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.AddOnId)
            .NotEmpty().WithMessage("AddOnId is required")
            .GreaterThan(0).WithMessage("AddOnId must be greater than 0");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}