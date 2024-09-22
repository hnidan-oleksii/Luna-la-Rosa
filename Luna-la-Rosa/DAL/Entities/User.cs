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

    public ShoppingCart ShoppingCart { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<CustomBouquet> CustomBouquets { get; set; }
}
