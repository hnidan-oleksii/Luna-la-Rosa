using BLL.DTO.Analytics;

namespace BLL.Services.Interfaces;

public interface IAnalyticsService
{
    Task<MainInfoDto> GetMainInfoAsync();
}