namespace DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string Status { get; set; }
    public decimal DeliveryPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string PaymentMethod { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; }
    public ICollection<OrderBouquet> OrderBouquets { get; set; }
    public Payment Payment { get; set; }
}