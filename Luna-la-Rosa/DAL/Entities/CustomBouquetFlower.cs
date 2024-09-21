namespace DAL.Entities;

public class CustomBouquetFlower
{
    public int CustomBouquetId { get; set; }
    public CustomBouquet CustomBouquet { get; set; }

    public int FlowerId { get; set; }
    public Flower Flower { get; set; }

    public int Quantity { get; set; }
}
