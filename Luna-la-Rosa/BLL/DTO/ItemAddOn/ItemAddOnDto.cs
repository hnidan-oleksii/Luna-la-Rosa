using BLL.DTO.AddOn;

namespace BLL.DTO.ItemAddOn;

public class ItemAddOnDto
{
    public int BouquetId { get; set; }
    public int AddOnId { get; set; }
	public int Quantity { get; set; }
	
	public AddOnDto AddOn { get; set; }
}