namespace DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactInformation { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ShoppingCart ShoppingCart { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<CustomBouquet> CustomBouquets { get; set; }
}
