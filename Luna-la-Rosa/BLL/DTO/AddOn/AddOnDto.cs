namespace BLL.DTO.AddOn;

public class AddOnDto
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
}
