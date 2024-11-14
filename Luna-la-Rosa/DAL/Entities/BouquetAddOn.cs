namespace DAL.Entities;

public class BouquetAddOn
{
    public int Id { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int AddOnId { get; set; }
    public int Quantity { get; set; }

    public Bouquet? Bouquet { get; set; }
    public CustomBouquet? CustomBouquet { get; set; }
    public AddOn? AddOn { get; set; }
}