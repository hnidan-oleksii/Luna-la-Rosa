namespace DAL.Entities;

public class Flower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<BouquetFlower> BouquetFlowers { get; set; }
    public ICollection<CustomBouquetFlower> CustomBouquetFlowers { get; set; }
}