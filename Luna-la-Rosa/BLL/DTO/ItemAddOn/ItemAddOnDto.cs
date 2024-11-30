using BLL.DTO.AddOn;

namespace BLL.DTO.ItemAddOn;

public class ItemAddOnDto
{
    public int Id { get; set; }
    public int? BouquetId { get; set; }
    public int? CustomBouquetId { get; set; }
    public int AddOnId { get; set; }
    public int Quantity { get; set; }
    public string? CardNote { get; set; }

    public AddOnDto? AddOn { get; set; }
}