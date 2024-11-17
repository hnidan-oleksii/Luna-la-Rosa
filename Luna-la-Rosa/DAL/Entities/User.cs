namespace DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ShoppingCart? ShoppingCart { get; set; }
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    public IEnumerable<CustomBouquet> CustomBouquets { get; set; } = new List<CustomBouquet>();
}