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

        try
        {
            await _addOnService.AddAddOnAsync(addOnDto, cancellationToken);
            return CreatedAtAction(nameof(GetAddOnsGroupedByType), new { id = addOnDto.Id }, addOnDto);
        }
        catch (ApplicationException ex)
        {
            return StatusCode(500, ex.Message);
        }
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

        try
        {
            await _addOnService.UpdateAddOnAsync(addOnDto, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ApplicationException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddOn(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _addOnService.DeleteAddOnAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ApplicationException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}