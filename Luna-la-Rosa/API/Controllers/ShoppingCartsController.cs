using System.Security.Claims;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpGet("users/shopping-cart")]
    public async Task<ActionResult<ShoppingCartDto>> GetShoppingCartByUserId()
    {
        var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdFromToken != null && int.TryParse(userIdFromToken, out var userId))
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync(userId);
            return Ok(shoppingCart);
        }
        return Unauthorized("You are not authorized to view this shopping cart.");
    }


    [HttpPut("{userId:int}")]
    public async Task<ActionResult<ShoppingCartDto>> ChangeItemQuantityInShoppingCart(int userId,
        [FromQuery] int itemId, [FromQuery] int quantity, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var shoppingCart =
            await _shoppingCartService.ChangeShoppingCartItemQuantityAsync(userId, itemId, quantity, cancellationToken);
        return Ok(shoppingCart);
    }
    
    [Authorize]
    [HttpPut("users/shopping-cart/change-quantity")]
    public async Task<ActionResult<ShoppingCartDto>> ChangeItemQuantityInShoppingCart([FromQuery] int itemId, 
        [FromQuery] int quantity, CancellationToken cancellationToken)
    {
        var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (userIdFromToken != null && int.TryParse(userIdFromToken, out var userId))
        {
            var shoppingCart = await _shoppingCartService.ChangeShoppingCartItemQuantityAsync(userId, 
                itemId, quantity, cancellationToken);
            return Ok(shoppingCart);
        }

        return Unauthorized("You are not authorized to change the quantity of items in this shopping cart.");
    }


    [HttpPut("{userId:int}/delete")]
    public async Task<ActionResult<ShoppingCartDto>> DeleteItemFromShoppingCart(int userId, [FromQuery] int itemId,
        CancellationToken cancellationToken)
    {
        var shoppingCart =
            await _shoppingCartService.DeleteItemFromShoppingCartAsync(userId, itemId, cancellationToken);
        return Ok(shoppingCart);
    }
    
    [Authorize]
    [HttpPut("users/shopping-cart/delete")]
    public async Task<ActionResult<ShoppingCartDto>> DeleteItemFromShoppingCart([FromQuery] int itemId, CancellationToken cancellationToken)
    {
        var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdFromToken != null && int.TryParse(userIdFromToken, out var userId))
        {
            var shoppingCart = await _shoppingCartService.DeleteItemFromShoppingCartAsync(userId, itemId, 
                cancellationToken);
            return Ok(shoppingCart);
        }

        return Unauthorized("You are not authorized to delete items from this shopping cart.");
    }
}