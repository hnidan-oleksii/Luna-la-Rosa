namespace DAL.Entities;

public class CartItemAddOnAssociation
{
    public int CartItemId { get; set; }
    public int AddOnId { get; set; }

    public CartItem CartItem { get; set; }
    public AddOn AddOn { get; set; }
}