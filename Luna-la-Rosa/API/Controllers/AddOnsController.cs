using BLL.DTO.AddOn;
using BLL.Services.Interfaces;
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
    public async Task<ActionResult<IEnumerable<AddOnDto>>> GetAllAddOnsAsync()
    {
        var addOns = await _addOnService.GetAllAddOnsAsync();
        return Ok(addOns);
    }
    
    [HttpGet]
    public async Task<ActionResult<Dictionary<string, List<AddOnDto>>>> GetAddOnsGroupedByType()
    {
        var addOns = await _addOnService.GetAddOnsGroupedByTypeAsync();
        return Ok(addOns);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAddOn([FromBody] AddOnDto addOnDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _addOnService.AddAddOnAsync(addOnDto, cancellationToken);
        return CreatedAtAction(nameof(GetAddOnsGroupedByType), new { id = addOnDto.Id }, addOnDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAddOn(int id, [FromBody] AddOnDto addOnDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != addOnDto.Id)
        {
            return BadRequest("ID mismatch");
        }

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