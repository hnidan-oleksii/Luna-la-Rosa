namespace DAL.Entities;

public class CustomBouquet
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public User? User { get; set; }
    public IEnumerable<BouquetAddOn> CustomBouquetAddOns { get; set; } = new List<BouquetAddOn>();
    public IEnumerable<CustomBouquetFlower> CustomBouquetFlowers { get; set; } = new List<CustomBouquetFlower>();
    public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    public IEnumerable<OrderBouquet> OrderBouquets { get; set; } = new List<OrderBouquet>();
}