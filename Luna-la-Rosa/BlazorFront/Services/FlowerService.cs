using BLL.DTO.AddOn;
using BLL.DTO.Flower;
using DAL.Helpers.Params;
using BlazorFront.Services.Interfaces;

namespace BlazorFront.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly HttpClient _httpClient;

        public FlowerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FlowerDto>> GetAllFlowersAsync(string searchQuery)
        {
            // Build the API URL with the search query if provided
            var url = "api/Flower/all";
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                url += $"?SearchQuery={searchQuery}";
            }

            // Fetch data from the API
            return await _httpClient.GetFromJsonAsync<IEnumerable<FlowerDto>>(url);
        }

        public async Task<Dictionary<string, List<FlowerDto>>> GetFlowersGroupedByTypeAsync()
        {
            return await _httpClient.GetFromJsonAsync<Dictionary<string, List<FlowerDto>>>("api/Flower");
        }

        public async Task<FlowerDto> GetFlowerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<FlowerDto>($"api/Flower/{id}");
        }

        public async Task<int> AddFlowerAsync(CreateFlowerDto flowerDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Flower", flowerDto, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to add Flower");
            }

            // Retrieve the newly created Flower's ID from the response
            var createdId = await response.Content.ReadFromJsonAsync<int>();
            return createdId;
        }

        public async Task UpdateFlowerAsync(FlowerDto flowerDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Flower/{flowerDto.Id}", flowerDto, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to update Flower");
            }
        }

        public async Task DeleteFlowerAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"api/Flower/{id}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to delete Flower");
            }
        }
    }
}
