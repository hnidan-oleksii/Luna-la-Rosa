using BLL.DTO.BouquetFlower;
using BLL.DTO.CustomBouquet;
using BLL.DTO.ItemAddOn;
using FluentValidation;

namespace BLL.Validation.CustomBouquet;

public class CreateCustomBouquetDtoValidator : AbstractValidator<CreateCustomBouquetDto>
{
    private const int MaxFlowersInBouquet = 101;

    public CreateCustomBouquetDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
        RuleFor(x => x.TotalPrice)
            .NotEmpty().WithMessage("TotalPrice is required")
            .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        RuleFor(x => x.CustomBouquetFlowers)
            .NotEmpty().WithMessage("CustomBouquetFlowers must not be empty")
            .Must(HaveValidSize).WithMessage("CustomBouquetFlowers must have size not exceeding 101");
        RuleFor(x => new { x.CustomBouquetFlowers, x.CustomBouquetAddOns, x.TotalPrice })
            .Must(x => HaveTotalPriceMatching(x.CustomBouquetFlowers, x.CustomBouquetAddOns, x.TotalPrice))
            .WithMessage("Calculated total price must be equal to dto total price");
    }

    private static bool HaveValidSize(IEnumerable<BouquetFlowerDto> flowers)
    {
        return flowers.Count() < MaxFlowersInBouquet;
    }

    private static bool HaveTotalPriceMatching(IEnumerable<BouquetFlowerDto> flowers, IEnumerable<ItemAddOnDto> addOns,
        decimal totalPrice)
    {
        var itemAddOnDtos = addOns.ToList();

        var calculatedTotalPrice = flowers.Sum(f => f.Quantity * f.Flower.Price);
        if (itemAddOnDtos.Count != 0)
            calculatedTotalPrice += itemAddOnDtos.Sum(ao => ao.Quantity * ao.AddOn.Price);

        return calculatedTotalPrice == totalPrice;
    }
}