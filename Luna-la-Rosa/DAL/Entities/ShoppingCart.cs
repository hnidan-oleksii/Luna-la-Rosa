namespace DAL.Entities;

public class ShoppingCart
{
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }

    public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
}