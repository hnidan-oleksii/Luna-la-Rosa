namespace BLL.DTO.Flower;

public class CreateFlowerDto
{
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
}