using BLL.DTO.ItemAddOn;

namespace BLL.DTO.ShoppingCart;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public IEnumerable<ItemAddOnDto> AddOns { get; set; } = new List<ItemAddOnDto>();
}