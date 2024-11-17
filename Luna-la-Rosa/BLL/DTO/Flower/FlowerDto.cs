namespace BLL.DTO.Flower;

public class FlowerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public byte[] Image { get; set; }
}