namespace DAL.Entities;

public class AddOnType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<AddOn> AddOn { get; set; }
}
