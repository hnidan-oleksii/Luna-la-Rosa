namespace DAL.Entities;

public class AddOnType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<AddOn> AddOn { get; set; } = new List<AddOn>();
}