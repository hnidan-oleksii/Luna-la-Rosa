namespace DAL.Entities;

public class BouquetCategoryBouquet
{
    public int BouquetId { get; set; }
    public int CategoryId { get; set; }

    public Bouquet Bouquet { get; set; }
    public BouquetCategory Category { get; set; }
}