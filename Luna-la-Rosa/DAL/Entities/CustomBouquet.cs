namespace DAL.Entities;

public class CustomBouquet
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<CustomBouquetFlower> CustomBouquetFlowers { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<OrderBouquet> OrderBouquets { get; set; }
}