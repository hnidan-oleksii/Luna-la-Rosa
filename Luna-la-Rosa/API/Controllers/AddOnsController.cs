using BLL.DTO.AddOn;
using BLL.Services.Interfaces;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddOnsController : ControllerBase
{
    private readonly IAddOnService _addOnService;

    public AddOnsController(IAddOnService addOnService)
    {
        _addOnService = addOnService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<AddOnDto>>> GetAllAddOnsAsync([FromQuery] AddOnParams addOnParams)
    {
        var addOns = await _addOnService.GetAllAddOnsAsync(addOnParams);
        return Ok(addOns);
    }

    [HttpGet]
    public async Task<ActionResult<Dictionary<string, List<AddOnDto>>>> GetAddOnsGroupedByType()
    {
        var addOns = await _addOnService.GetAddOnsGroupedByTypeAsync();
        return Ok(addOns);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddOnDto>> GetAddOnById(int id)
    {
        var addOn = await _addOnService.GetAddOnByIdAsync(id);
        return Ok(addOn);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddOn([FromBody] CreateAddOnDto addOnDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdId = await _addOnService.AddAddOnAsync(addOnDto, cancellationToken);
        return CreatedAtAction(nameof(GetAddOnById), new { id = createdId }, addOnDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAddOn(int id, [FromBody] AddOnDto addOnDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != addOnDto.Id) return BadRequest("ID mismatch");

        await _addOnService.UpdateAddOnAsync(addOnDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddOn(int id, CancellationToken cancellationToken)
    {
        await _addOnService.DeleteAddOnAsync(id, cancellationToken);
        return NoContent();
    }
}