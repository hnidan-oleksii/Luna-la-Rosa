using BLL.DTO.Order;
using FluentValidation;

namespace BLL.Validation.Order;

public class OrderBouquetDtoValidator : AbstractValidator<OrderBouquetDto>
{
    public OrderBouquetDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required")
            .GreaterThan(0).WithMessage("OrderId must be greater than 0");
        RuleFor(x => x.BouquetId)
            .GreaterThan(0).WithMessage("BouquetId must be greater than 0")
            .When(x => x.BouquetId != null);
        RuleFor(x => x.CustomBouquetId)
            .GreaterThan(0).WithMessage("CustomBouquetId must be greater than 0")
            .When(x => x.CustomBouquetId != null);
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => new { x.BouquetId, x.CustomBouquetId })
            .Must(x => HaveOneAssociatedBouquet(x.BouquetId, x.CustomBouquetId));
    }

    private static bool HaveOneAssociatedBouquet(int? bouquetId, int? customBouquetId)
    {
        var bouquetIdProvided = bouquetId.HasValue;
        var customBouquetIdProvided = customBouquetId.HasValue;

        return bouquetIdProvided ^ customBouquetIdProvided;
    }
}