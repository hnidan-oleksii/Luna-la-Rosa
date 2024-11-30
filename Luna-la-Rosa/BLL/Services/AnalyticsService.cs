using BLL.DTO.Analytics;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnalyticsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MainInfoDto> GetMainInfoAsync()
    {
        var mainInfoDto = new MainInfoDto()
        {
            TotalProfit = await GetTotalProfit(),
            TotalFlowerCount = await GetTotalFlowerCount(),
            AvgFlowerPrice = await GetAvgFlowerPrice(),
            AvgBouquetPrice = await GetAvgBouquetPrice(),
            AvgCheckPrice = await GetAvgCheckPrice(),
            AvgDailyOrders = await GetAvgDailyOrders()
        };
        return mainInfoDto;
    }

    private async Task<double> GetTotalProfit()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var totalProfit = orders.Sum(o => (double)o.TotalPrice);
        return totalProfit;
    }

    private async Task<long> GetTotalFlowerCount()
    {
        var flowers = await _unitOfWork.Flowers.GetAllAsync();
        var totalFlowerCount = flowers.Sum(f => f.AvailableQuantity);
        return totalFlowerCount;
    }

    private async Task<decimal> GetAvgFlowerPrice()
    {
        var flowers = await _unitOfWork.Flowers.GetAllAsync();
        var avgFlowerPrice = flowers.Select(f => f.Price).Average();
        return avgFlowerPrice;
    }

    private async Task<decimal> GetAvgBouquetPrice()
    {
        var bouquets = await _unitOfWork.Bouquets.GetAllAsync();
        var avgBouquetPrice = bouquets.Select(b => b.Price).Average();
        return avgBouquetPrice;
    }

    private async Task<decimal> GetAvgCheckPrice()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var avgCheckPrice = orders.Select(o => o.TotalPrice).Average();
        return avgCheckPrice;
    }

    private async Task<double> GetAvgDailyOrders()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var ordersList = orders.ToList();

        var firstOrderDate = ordersList.OrderBy(o => o.CreatedAt).First().CreatedAt;
        var todayDate = DateTime.Today;
        var dateDiffDayCount = (todayDate - firstOrderDate).Days;

        var groupedByDateOrders = ordersList
            .GroupBy(o => o.CreatedAt.Date)
            .OrderBy(o => o.Key)
            .Select(groupedOrders => new
            {
                OrdersCount = groupedOrders.Count()
            });
        var avgDailyOrders = groupedByDateOrders.Sum(go => go.OrdersCount) / dateDiffDayCount;

        return avgDailyOrders;
    }
}