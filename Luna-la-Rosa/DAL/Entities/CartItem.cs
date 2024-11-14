namespace DAL.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public ShoppingCart? ShoppingCart { get; set; }
    public Bouquet? Bouquet { get; set; }
    public CustomBouquet? CustomBouquet { get; set; }
    public IEnumerable<CartItemAddOn> AddOns { get; set; } = new List<CartItemAddOn>();
}