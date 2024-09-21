namespace DAL.Entities;

public class CustomBouquet
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }
    public decimal? TotalPrice { get; set; }
    public string Ribbon { get; set; }
    public string Wrapping { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<CustomBouquetFlower> CustomBouquetFlowers { get; set; }
}
