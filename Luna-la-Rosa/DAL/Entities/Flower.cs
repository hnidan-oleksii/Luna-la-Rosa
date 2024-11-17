namespace DAL.Entities;

public class Flower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public FlowerType? Type { get; set; }
    public IEnumerable<BouquetFlower> BouquetFlowers { get; set; } = new List<BouquetFlower>();
    public IEnumerable<CustomBouquetFlower> CustomBouquetFlowers { get; set; } = new List<CustomBouquetFlower>();
}