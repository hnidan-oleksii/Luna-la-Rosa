namespace DAL.Entities;

public class BouquetFlower
{
    public int BouquetId { get; set; }
    public int FlowerId { get; set; }
    public int Quantity { get; set; }

    public Bouquet Bouquet { get; set; }
    public Flower Flower { get; set; }
}
