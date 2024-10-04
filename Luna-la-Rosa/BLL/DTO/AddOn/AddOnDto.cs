namespace BLL.DTO;

public class AddOnDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
}