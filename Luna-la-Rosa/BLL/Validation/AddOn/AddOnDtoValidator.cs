using BLL.DTO.AddOn;
using FluentValidation;

namespace BLL.Validation.AddOn;

public class AddOnDtoValidator : AbstractValidator<AddOnDto>
{
    public AddOnDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.TypeId)
            .NotEmpty().WithMessage("Type is required")
            .GreaterThan(0).WithMessage("TypeId must be greater than 0");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 255).WithMessage("Name length must be between 1 and 255 characters");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value");
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Image is required");
    }
}