namespace DAL.Entities;

public class Bouquet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string MainColor { get; set; }
    public string Size { get; set; }
    public byte[] Image { get; set; }
    public string Description { get; set; }
    public int PopularityScore { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public IEnumerable<BouquetAddOn> BouquetAddOns { get; set; } = new List<BouquetAddOn>();
    public IEnumerable<BouquetCategoryBouquet> BouquetCategories { get; set; } = new List<BouquetCategoryBouquet>();
    public IEnumerable<BouquetFlower> BouquetFlowers { get; set; } = new List<BouquetFlower>();
    public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    public IEnumerable<OrderBouquet> OrderBouquets { get; set; } = new List<OrderBouquet>();
}