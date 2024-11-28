using BLL.DTO.Bouquet;
using FluentValidation;

namespace BLL.Validation.Bouquet;

public class CreateBouquetDtoValidator : AbstractValidator<CreateBouquetDto>
{
    public CreateBouquetDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(30).WithMessage("Name length must be between 1 and 30 characters");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(30).WithMessage("Description length must be between 1 and 30 characters");
        RuleFor(x => x.Size)
            .NotEmpty().WithMessage("Size is required")
            .MaximumLength(50).WithMessage("Size length must be between 1 and 50 characters")
            .Must(BeValidSize).WithMessage("Size must be one of the following: Small, Medium, Large");
        RuleFor(x => x.MainColor)
            .NotEmpty().WithMessage("MainColor is required")
            .MaximumLength(50).WithMessage("MainColor length must be between 1 and 50 characters");
        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image is required");
    }

    private bool BeValidSize(string size)
    {
        var validSizes = new[] { "Small", "Medium", "Large" };
        return validSizes.Contains(size);
    }
}