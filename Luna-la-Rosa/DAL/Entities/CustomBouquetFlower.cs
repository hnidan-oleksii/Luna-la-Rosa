namespace DAL.Entities;

public class CustomBouquetFlower
{
    public int CustomBouquetId { get; set; }
    public int FlowerId { get; set; }
    public int Quantity { get; set; }

    public CustomBouquet CustomBouquet { get; set; }
    public Flower Flower { get; set; }
}