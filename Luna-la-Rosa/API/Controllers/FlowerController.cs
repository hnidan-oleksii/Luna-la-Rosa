using BLL.DTO.Flower;
using BLL.Services.Interfaces;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class FlowerController : ControllerBase
{
    private readonly IFlowerService _flowerService;

    public FlowerController(IFlowerService flowerService)
    {
        _flowerService = flowerService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<FlowerDto>>> GetAllFlowersAsync([FromQuery] FlowerParams flowerParams)
    {
        var flowers = await _flowerService.GetAllFlowersAsync(flowerParams);
        return Ok(flowers);
    }

    [HttpGet]
    public async Task<ActionResult<Dictionary<string, List<FlowerDto>>>> GetFlowersGroupedByType()
    {
        var flowers = await _flowerService.GetFlowersGroupedByTypeAsync();
        return Ok(flowers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FlowerDto>> GetFlowerById(int id)
    {
        var flower = await _flowerService.GetFlowerByIdAsync(id);
        return Ok(flower);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddFlower([FromBody] CreateFlowerDto flowerDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdId = await _flowerService.AddFlowerAsync(flowerDto, cancellationToken);
        return CreatedAtAction(nameof(GetFlowerById), new { id = createdId }, flowerDto);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFlower(int id, [FromBody] FlowerDto flowerDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != flowerDto.Id) return BadRequest("ID mismatch");

        await _flowerService.UpdateFlowerAsync(flowerDto, cancellationToken);
        return NoContent();
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlower(int id, CancellationToken cancellationToken)
    {
        await _flowerService.DeleteFlowerAsync(id, cancellationToken);
        return NoContent();
    }
}