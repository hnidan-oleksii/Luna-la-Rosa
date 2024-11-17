namespace DAL.Entities;

public class BouquetCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public IEnumerable<BouquetCategoryBouquet> Bouquets { get; set; } = new List<BouquetCategoryBouquet>();
}