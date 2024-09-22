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
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<BouquetCategoryAssociation> BouquetCategories { get; set; }
    public ICollection<BouquetFlower> BouquetFlowers { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<OrderBouquet> OrderBouquets { get; set; }
}