namespace DAL.Entities;

public class AddOn
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public AddOnType? Type { get; set; }
    public IEnumerable<BouquetAddOn> BouquetAddOns { get; set; } = new List<BouquetAddOn>();
    public IEnumerable<CartItemAddOn> CartItems { get; set; } = new List<CartItemAddOn>();
    public IEnumerable<OrderAddOn> OrderBouquets { get; set; } = new List<OrderAddOn>();
}