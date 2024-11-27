namespace BLL.DTO.Order;

public class OrderDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Status { get; set; }
    public decimal DeliveryPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string DeliveryCity { get; set; }
    public string DeliveryStreet { get; set; }
    public string DeliveryBuilding { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string PaymentMethod { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<OrderBouquetDto> OrderBouquets { get; set; } = new List<OrderBouquetDto>();
}