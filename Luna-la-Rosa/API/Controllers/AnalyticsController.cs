using BLL.DTO.Analytics;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsController(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("main")]
    public async Task<ActionResult<MainInfoDto>> GetMainInfo()
    {
        var info = await _analyticsService.GetMainInfoAsync();
        return Ok(info);
    }
}