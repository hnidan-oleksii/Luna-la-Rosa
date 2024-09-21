namespace DAL.Entities;

public class OrderBouquet
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int? BouquetId { get; set; }
    public Bouquet Bouquet { get; set; }

    public int? CustomBouquetId { get; set; }
    public CustomBouquet CustomBouquet { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    public ICollection<OrderAddOn> OrderAddOns { get; set; }
}
