using BLL.DTO.BouquetFlower;
using BLL.DTO.ItemAddOn;

namespace BLL.DTO.CustomBouquet;

public class CreateCustomBouquetDto
{
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }

    public IEnumerable<ItemAddOnDto> CustomBouquetAddOns { get; set; } = new List<ItemAddOnDto>();
    public IEnumerable<BouquetFlowerDto> CustomBouquetFlowers { get; set; } = new List<BouquetFlowerDto>();
}