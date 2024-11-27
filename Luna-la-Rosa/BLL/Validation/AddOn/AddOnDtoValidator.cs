using BLL.DTO.AddOn;
using FluentValidation;

namespace BLL.Validation.AddOn;

public class AddOnDtoValidator : AbstractValidator<AddOnDto>
{
    public AddOnDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required");
        RuleFor(x => x.TypeId)
            .NotNull().WithMessage("Type is required");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 255).WithMessage("Name must be between 1 and 255 characters");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value");
        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image is required");
    }
}