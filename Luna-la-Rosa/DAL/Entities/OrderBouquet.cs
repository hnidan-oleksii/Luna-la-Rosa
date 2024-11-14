namespace DAL.Entities;

public class OrderBouquet
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order? Order { get; set; }
    public Bouquet? Bouquet { get; set; }
    public CustomBouquet? CustomBouquet { get; set; }
    public IEnumerable<OrderAddOn> AddOns { get; set; } = new List<OrderAddOn>();
}