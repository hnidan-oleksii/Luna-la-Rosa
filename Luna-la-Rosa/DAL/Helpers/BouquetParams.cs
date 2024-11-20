namespace DAL.Helpers;

public class BouquetParams : QueryParams
{
    public BouquetParams()
    {
        OrderBy = "PopularityScore";
    }

    public string? SearchQuery { get; set; }
    public string? BouquetCategories { get; set; }
    public string? MainColor { get; set; }
    public string? Size { get; set; }
    public string? FlowerTypeNames { get; set; }
    public uint MinPrice { get; set; }
    public uint MaxPrice { get; set; }

    public bool ValidPriceRange => MinPrice <= MaxPrice;
}