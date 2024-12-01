using BLL.DTO.Bouquet;
using BLL.DTO.ItemAddOn;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using DAL.Helpers;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Authorization;
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

    //[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult> CreateBouquet([FromBody] CreateBouquetDto createBouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdBouquetId = await _bouquetService.AddBouquetAsync(createBouquetDto, cancellationToken);
        return CreatedAtAction(nameof(GetBouquetById), new { id = createdBouquetId }, createdBouquetId);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut("id")]
    public async Task<ActionResult> UpdateBouquet(int id, [FromBody] BouquetDto bouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != bouquetDto.Id) return BadRequest("ID mismatch");

        await _bouquetService.UpdateBouquetAsync(bouquetDto, cancellationToken);
        return NoContent();
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("id")]
    public async Task<ActionResult> DeleteBouquet(int id, CancellationToken cancellationToken)
    {
        await _bouquetService.DeleteBouquetAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("order")]
    public async Task<ActionResult<ShoppingCartDto>> AddBouquetToShoppingCart([FromQuery] int bouquetId,
        [FromQuery] int userId, [FromBody] IEnumerable<ItemAddOnDto> addOns, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var cart = await _bouquetService.AddBouquetToCartAsync(bouquetId, addOns, userId, cancellationToken);
        return Ok(cart);
    }
}