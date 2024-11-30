using BLL.DTO.ItemAddOn;

namespace BLL.DTO.Order;

public class OrderBouquetDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public IEnumerable<ItemAddOnDto> AddOns { get; set; } = new List<ItemAddOnDto>();
}