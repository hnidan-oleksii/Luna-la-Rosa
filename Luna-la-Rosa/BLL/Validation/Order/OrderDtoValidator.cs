using BLL.DTO.Order;
using FluentValidation;

namespace BLL.Validation.Order;

public class OrderDtoValidator : AbstractValidator<OrderDto>
{
    public OrderDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required")
            .Length(1, 50).WithMessage("Status length must be between 1 and 50 characters");
        RuleFor(x => x.DeliveryPrice)
            .NotEmpty().WithMessage("DeliveryPrice is required")
            .GreaterThan(0).WithMessage("DeliveryPrice must be greater than 0");
        RuleFor(x => x.TotalPrice)
            .NotEmpty().WithMessage("TotalPrice is required")
            .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        RuleFor(x => x.DeliveryCity)
            .NotEmpty().WithMessage("DeliveryCity is required");
        RuleFor(x => x.DeliveryStreet)
            .NotEmpty().WithMessage("DeliveryStreet is required");
        RuleFor(x => x.DeliveryBuilding)
            .NotEmpty().WithMessage("DeliveryBuilding is required");
        RuleFor(x => x.DeliveryDate)
            .NotEmpty().WithMessage("DeliveryDate is required")
            .GreaterThan(DateTime.Now).WithMessage("DeliveryDate must be greater than present date and time");
        RuleFor(x => x.PaymentMethod)
            .NotEmpty().WithMessage("PaymentMethod is required")
            .Length(1, 50).WithMessage("PaymentMethod length must be between 1 and 50 characters")
            .Must(BeValidPaymentMethod)
            .WithMessage("PaymentMethod must be one of the following: Card, Cash on Delivery");
    }

    private static bool BeValidPaymentMethod(string paymentMethod)
    {
        var validPaymentMethods = new[] { "Card", "Cash on Delivery" };
        return validPaymentMethods.Contains(paymentMethod);
    }
}