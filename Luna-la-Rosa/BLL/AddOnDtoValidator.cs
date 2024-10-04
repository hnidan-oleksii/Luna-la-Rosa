using BLL.DTO;
using FluentValidation;

namespace BLL;

public class AddOnDtoValidator : AbstractValidator<AddOnDto>
{
    public AddOnDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required.");
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required.")
            .Length(1, 50).WithMessage("Type must be between 1 and 50 characters.")
            .Must(BeAValidType).WithMessage("Type must be one of the following: 'Balloons', 'Card', 'Sweets', " +
                                            "'Wrapping', 'Ribbon'.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(1, 255).WithMessage("Name must be between 1 and 255 characters.");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value.");
        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image is required.");
    }
    private bool BeAValidType(string type)
    {
        var validTypes = new[] { "Balloons", "Card", "Sweets", "Wrapping", "Ribbon" };
        return validTypes.Contains(type);
    }
}