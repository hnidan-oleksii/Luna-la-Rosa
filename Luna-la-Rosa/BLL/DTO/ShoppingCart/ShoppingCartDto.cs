namespace BLL.DTO.ShoppingCart;

public class ShoppingCartDto
{
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
}