using BLL.DTO.BouquetCategoryBouquet;
using BLL.DTO.BouquetFlower;
using BLL.DTO.ItemAddOn;

namespace BLL.DTO.Bouquet;

public class CreateBouquetDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string MainColor { get; set; }
    public string Size { get; set; }
    public byte[] Image { get; set; }
    public string Description { get; set; }

    public ICollection<BouquetFlowerDto> Flowers { get; set; }
    public ICollection<BouquetCategoryBouquetDto>? Categories { get; set; }
    public ICollection<ItemAddOnDto>? AddOns { get; set; }
}