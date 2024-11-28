namespace BlazorFront.Services
{
    using BlazorFront.Services.Interfaces;
    using BLL.DTO.AddOn;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOnService : IAddOnService
    {
        private readonly HttpClient _httpClient;

        public AddOnService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AddOnDto>> GetAllAddOnsAsync(string searchQuery)
        {
            // Build the API URL with the search query if provided
            var url = "api/AddOns/all";
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                url += $"?SearchQuery={searchQuery}";
            }

            // Fetch data from the API
            return await _httpClient.GetFromJsonAsync<IEnumerable<AddOnDto>>(url);
        }

        public async Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync()
        {
            return await _httpClient.GetFromJsonAsync<Dictionary<string, List<AddOnDto>>>("api/AddOns");
        }

        public async Task<AddOnDto> GetAddOnByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AddOnDto>($"api/AddOns/{id}");
        }

        public async Task<int> AddAddOnAsync(CreateAddOnDto addOnDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AddOns", addOnDto, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to add AddOn");
            }

            // Retrieve the newly created AddOn's ID from the response
            var createdId = await response.Content.ReadFromJsonAsync<int>();
            return createdId;
        }

        public async Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/AddOns/{addOnDto.Id}", addOnDto, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to update AddOn");
            }
        }

        public async Task DeleteAddOnAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"api/AddOns/{id}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to delete AddOn");
            }
        }
    }

}
