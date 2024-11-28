using BLL.DTO.Bouquet;
using DAL.Helpers.Params;
using DAL.Helpers;
using System.Text.Json;
using BlazorFront.Services.Interfaces;

namespace BlazorFront.Services
{
    public class BouquetService : IBouquetService
    {
        private readonly HttpClient _httpClient;

        public BouquetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BouquetDto>> GetAllBouquetsAsync(BouquetParams bouquetParams)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(bouquetParams.SearchQuery))
                queryParams.Add($"SearchQuery={bouquetParams.SearchQuery}");

            if (!string.IsNullOrWhiteSpace(bouquetParams.BouquetCategories))
                queryParams.Add($"BouquetCategories={bouquetParams.BouquetCategories}");

            if (!string.IsNullOrWhiteSpace(bouquetParams.MainColor))
                queryParams.Add($"MainColor={bouquetParams.MainColor}");

            if (!string.IsNullOrWhiteSpace(bouquetParams.Size))
                queryParams.Add($"Size={bouquetParams.Size}");

            if (!string.IsNullOrWhiteSpace(bouquetParams.FlowerTypeNames))
                queryParams.Add($"FlowerTypeNames={bouquetParams.FlowerTypeNames}");

            if (bouquetParams.MinPrice > 0)
                queryParams.Add($"MinPrice={bouquetParams.MinPrice}");

            if (bouquetParams.MaxPrice > 0)
                queryParams.Add($"MaxPrice={bouquetParams.MaxPrice}");

            if (bouquetParams.PageNumber > 0)
                queryParams.Add($"PageNumber={bouquetParams.PageNumber}");

            if (bouquetParams.PageSize > 0)
                queryParams.Add($"PageSize={bouquetParams.PageSize}");

            var url = "api/Bouquets";
            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<BouquetDto>>(options);

            return result ?? new List<BouquetDto>();
        }

        public async Task<BouquetDto> GetBouquetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BouquetDto>($"api/Bouquets/{id}");
        }

        public async Task<int> AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Bouquets", bouquetDto, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to create bouquet");
            }

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Bouquets/{bouquetDto.Id}", bouquetDto, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to update bouquet");
            }
        }

        public async Task DeleteBouquetAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"api/Bouquets/{id}", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to delete bouquet");
            }
        }
    }
}
