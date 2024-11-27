using BLL.DTO.Flower;
using FluentValidation;

namespace BLL.Validation.Flower;

public class CreateFlowerDtoValidator : AbstractValidator<CreateFlowerDto>
{
    public CreateFlowerDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 255).WithMessage("Name length must be between 1 and 255 characters");
        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Color is required")
            .Length(1, 50).WithMessage("Color length must be between 1 and 50 characters");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Image is required");
        RuleFor(x => x.TypeId)
            .NotEmpty().WithMessage("TypeId is required")
            .GreaterThan(0).WithMessage("TypeId must be greater than 0");
    }
}