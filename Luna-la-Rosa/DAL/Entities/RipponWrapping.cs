namespace DAL.Entities;

public class RibbonWrapping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Photo { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public int AvailableQuantity { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<CustomBouquet> CustomBouquetsAsRibbon { get; set; }
    public ICollection<CustomBouquet> CustomBouquetsAsWrapping { get; set; }
}