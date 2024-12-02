using BLL.DTO.ShoppingCart;

namespace BlazorFront.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> GetShoppingCartByUserIdAsync(int userId);
        Task<ShoppingCartDto> ChangeShoppingCartItemQuantityAsync(int userId, int itemId, int quantity, CancellationToken cancellationToken);
        Task<ShoppingCartDto> DeleteItemFromShoppingCartAsync(int userId, int itemId, CancellationToken cancellationToken);
    }
}
