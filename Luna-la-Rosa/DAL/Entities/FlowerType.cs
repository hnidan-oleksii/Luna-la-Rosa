namespace DAL.Entities;

public class FlowerType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Flower> Flower { get; set; }
}
