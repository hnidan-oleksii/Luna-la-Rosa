namespace DAL.Entities;

public class Bouquet
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int PopularityScore { get; set; } = 0;
    public string MainColor { get; set; }
    public string Size { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<BouquetFlower> BouquetFlowers { get; set; }
    public ICollection<BouquetCategoryAssociation> BouquetCategoryAssociations { get; set; }
}
