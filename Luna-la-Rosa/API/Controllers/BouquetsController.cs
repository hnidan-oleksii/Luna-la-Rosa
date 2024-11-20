using BLL.DTO.Bouquet;
using BLL.Services.Interfaces;
using DAL.Helpers;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class BouquetsController : ControllerBase
{
    private readonly IBouquetService _bouquetService;

    public BouquetsController(IBouquetService bouqeutService)
    {
        _bouquetService = bouqeutService;
    }

    [HttpGet]
    public ActionResult<PagedList<BouquetDto>> GetAllBouquetsAsync([FromQuery] BouquetParams bouquetParams)
    {
        var bouquets = _bouquetService.GetBouquets(bouquetParams);
        return Ok(bouquets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BouquetDto>> GetBouquetById(int id)
    {
        var bouquet = await _bouquetService.GetBouquetByIdAsync(id);
        return Ok(bouquet);
    }

    [HttpPost]
    public async Task<ActionResult> CreateBouquet([FromBody] CreateBouquetDto createBouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdBouquetId = await _bouquetService.AddBouquetAsync(createBouquetDto, cancellationToken);
        return CreatedAtAction(nameof(GetBouquetById), new { id = createdBouquetId }, createdBouquetId);
    }

    [HttpPut("id")]
    public async Task<ActionResult> UpdateBouquet(int id, [FromBody] BouquetDto bouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != bouquetDto.Id) return BadRequest("ID mismatch");

        await _bouquetService.UpdateBouquetAsync(bouquetDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteBouquet(int id, CancellationToken cancellationToken)
    {
        await _bouquetService.DeleteBouquetAsync(id, cancellationToken);
        return NoContent();
    }
}