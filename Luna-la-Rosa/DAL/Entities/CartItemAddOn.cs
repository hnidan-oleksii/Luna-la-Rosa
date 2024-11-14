namespace DAL.Entities;

public class CartItemAddOn
{
    public int CartItemId { get; set; }
    public int AddOnId { get; set; }
    public int Quantity { get; set; }
    public string? CardNote { get; set; }

    public CartItem? CartItem { get; set; }
    public AddOn? AddOn { get; set; }
}