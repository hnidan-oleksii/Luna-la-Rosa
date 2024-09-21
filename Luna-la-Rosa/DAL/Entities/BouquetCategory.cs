namespace DAL.Entities;

public class BouquetCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public ICollection<BouquetCategoryAssociation> BouquetCategoryAssociations { get; set; }
}
