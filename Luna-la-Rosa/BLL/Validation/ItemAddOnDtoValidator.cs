using BLL.DTO.ItemAddOn;
using FluentValidation;

namespace BLL.Validation;

public class ItemAddOnDtoValidator : AbstractValidator<ItemAddOnDto>
{
    public ItemAddOnDtoValidator()
    {
        RuleFor(x => x.AddOnId)
            .NotEmpty().WithMessage("AddOn ID is required.");
        RuleFor(x => x.Quantity).NotEmpty()
            .GreaterThan(0).WithMessage("Item quantity must be greater than 0");
    }
}