namespace DAL.Entities;

public class OrderAddOn
{
    public int OrderBouquetId { get; set; }
    public int AddOnId { get; set; }

    public OrderBouquet OrderBouquet { get; set; }
    public AddOn AddOn { get; set; }
}