using BlazorFront.Services.Interfaces;
using BLL.DTO.CustomBouquet;
using BLL.DTO.ShoppingCart;

namespace BlazorFront.Services
{
    public class CustomBouquetService : ICustomBouquetService
    {
        private readonly HttpClient _httpClient;

        public CustomBouquetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CustomBouquetDto>($"api/CustomBouquets/{id}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching Custom Bouquet with ID {id}: {ex.Message}");
            }
        }

        public async Task<ShoppingCartDto> CreateCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/CustomBouquets", customBouquetDto, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error creating Custom Bouquet: {response.ReasonPhrase}");
                }

                return await response.Content.ReadFromJsonAsync<ShoppingCartDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error creating Custom Bouquet: {ex.Message}");
            }
        }

        public async Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/CustomBouquets/{customBouquetDto.Id}", customBouquetDto, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error updating Custom Bouquet with ID {customBouquetDto.Id}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error updating Custom Bouquet with ID {customBouquetDto.Id}: {ex.Message}");
            }
        }
    }
}
