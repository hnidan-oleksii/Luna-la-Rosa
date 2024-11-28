using BLL.DTO.ShoppingCart;

namespace BLL.Services.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCartDto> GetShoppingCartByUserIdAsync(int userId);

    Task<ShoppingCartDto> ChangeShoppingCartItemQuantityAsync(int shoppingCartId, int shoppingCartItemId, int quantity,
        CancellationToken cancellationToken);

    Task<ShoppingCartDto> DeleteItemFromShoppingCartAsync(int shoppingCartId, int shoppingCartItemId,
        CancellationToken cancellationToken);
}