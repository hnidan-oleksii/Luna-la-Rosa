namespace DAL.Entities;

public class BouquetAddOn
{
    public int BouquetId { get; set; }
    public int AddOnId { get; set; }
	public int Quantity { get; set; }

    public Bouquet Bouquet { get; set; }
    public AddOn AddOn { get; set; }
}

