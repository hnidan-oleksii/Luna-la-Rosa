namespace BLL.DTO.Analytics;

public class MainInfoDto
{
    public double TotalProfit { get; set; }
    public long TotalFlowerCount { get; set; }
    public decimal AvgFlowerPrice { get; set; }
    public decimal AvgBouquetPrice { get; set; }
    public decimal AvgCheckPrice { get; set; }
    public double AvgDailyOrders { get; set; }
}