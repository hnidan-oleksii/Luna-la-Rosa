namespace DAL.Entities;

public class BouquetCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public ICollection<BouquetCategoryBouquet> Bouquets { get; set; }
}