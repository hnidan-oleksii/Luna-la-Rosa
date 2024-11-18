namespace BLL.DTO.AddOn;

public class CreateAddOnDto
{
    public int TypeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
}