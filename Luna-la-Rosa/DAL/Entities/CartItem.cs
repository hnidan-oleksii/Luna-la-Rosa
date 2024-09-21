namespace DAL.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public ShoppingCart Cart { get; set; }

    public int? BouquetId { get; set; }
    public Bouquet Bouquet { get; set; }

    public int? CustomBouquetId { get; set; }
    public CustomBouquet CustomBouquet { get; set; }

    public int Quantity { get; set; }
}
