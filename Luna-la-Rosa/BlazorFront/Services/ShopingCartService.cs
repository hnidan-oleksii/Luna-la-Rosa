using BlazorFront.Services.Interfaces;
using BLL.DTO.ShoppingCart;

namespace BlazorFront.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShoppingCartDto> GetShoppingCartByUserIdAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ShoppingCartDto>($"api/ShoppingCarts/{userId}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching shopping cart for user {userId}: {ex.Message}");
            }
        }

        public async Task<ShoppingCartDto> ChangeShoppingCartItemQuantityAsync(int userId, int itemId, int quantity, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PutAsync(
                    $"api/ShoppingCarts/{userId}?itemId={itemId}&quantity={quantity}",
                    null,
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to change quantity for item {itemId} in shopping cart for user {userId}: {response.ReasonPhrase}");
                }

                return await response.Content.ReadFromJsonAsync<ShoppingCartDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error updating item quantity in shopping cart: {ex.Message}");
            }
        }

        public async Task<ShoppingCartDto> DeleteItemFromShoppingCartAsync(int userId, int itemId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PutAsync(
                    $"api/ShoppingCarts/{userId}/delete?itemId={itemId}",
                    null,
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to delete item {itemId} from shopping cart for user {userId}: {response.ReasonPhrase}");
                }

                return await response.Content.ReadFromJsonAsync<ShoppingCartDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error deleting item from shopping cart: {ex.Message}");
            }
        }
    }
}
