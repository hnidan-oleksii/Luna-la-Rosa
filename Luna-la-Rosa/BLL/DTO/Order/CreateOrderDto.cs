using BLL.DTO.ShoppingCart;

namespace BLL.DTO.Order;

public class CreateOrderDto
{
    public int UserId { get; set; }
    public decimal DeliveryPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string DeliveryCity { get; set; }
    public string DeliveryStreet { get; set; }
    public string DeliveryBuilding { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string PaymentMethod { get; set; }
    public string? Comment { get; set; }

    public ShoppingCartDto ShoppingCart { get; set; }
}