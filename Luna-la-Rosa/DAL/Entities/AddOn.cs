namespace DAL.Entities;

public class AddOn
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }

	public AddOnType Type { get; set; }
    public ICollection<BouquetAddOn> BouquetAddOns { get; set; }
    public ICollection<CartItemAddOn> CartItems { get; set; }
    public ICollection<OrderAddOn> OrderBouquets { get; set; }
}
