using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartsController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartsController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet("{userId:int}")]
    public async Task<ActionResult<ShoppingCartDto>> GetShoppingCartByUserId(int userId)
    {
        var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync(userId);
        return Ok(shoppingCart);
    }

    [HttpPut("{userId:int}")]
    public async Task<ActionResult<ShoppingCartDto>> ChangeItemQuantityInShoppingCart(int userId,
        [FromQuery] int itemId, [FromQuery] int quantity, CancellationToken cancellationToken)
    {
        var shoppingCart =
            await _shoppingCartService.ChangeShoppingCartItemQuantityAsync(userId, itemId, quantity, cancellationToken);
        return Ok(shoppingCart);
    }

    [HttpPut("{userId:int}/delete")]
    public async Task<ActionResult<ShoppingCartDto>> DeleteItemFromShoppingCart(int userId, [FromQuery] int itemId,
        CancellationToken cancellationToken)
    {
        var shoppingCart =
            await _shoppingCartService.DeleteItemFromShoppingCartAsync(userId, itemId, cancellationToken);
        return Ok(shoppingCart);
    }
}