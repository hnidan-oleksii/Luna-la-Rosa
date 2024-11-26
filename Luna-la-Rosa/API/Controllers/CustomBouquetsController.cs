using BLL.DTO.CustomBouquet;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class CustomBouquetsController : ControllerBase
{
    private readonly ICustomBouquetService _customBouquetService;

    public CustomBouquetsController(ICustomBouquetService customBouquetService)
    {
        _customBouquetService = customBouquetService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomBouquetDto>> GetCustomBouquetById(int id)
    {
        var customBouquet = await _customBouquetService.GetCustomBouquetByIdAsync(id);
        return Ok(customBouquet);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCartDto>> CreateCustomBouquet(
        [FromBody] CreateCustomBouquetDto customBouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var shoppingCart = await _customBouquetService.AddCustomBouquetAsync(customBouquetDto, cancellationToken);
        return Created($"http://luna.api/api/shoppingCarts/{shoppingCart.UserId}", shoppingCart);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCustomBouquet(int id, [FromBody] CustomBouquetDto customBouquetDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != customBouquetDto.Id) return BadRequest("ID mismatch");

        await _customBouquetService.UpdateCustomBouquetAsync(customBouquetDto, cancellationToken);
        return NoContent();
    }
}