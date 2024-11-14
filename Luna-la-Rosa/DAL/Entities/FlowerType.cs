namespace DAL.Entities;

public class FlowerType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Flower> Flower { get; set; } = new List<Flower>();
}