using BLL.DTO.Flower;
using DAL.Helpers.Params;

namespace BlazorFront.Services.Interfaces
{
    public interface IFlowerService
    {
        Task<IEnumerable<FlowerDto>> GetAllFlowersAsync(string searchQuery);
        Task<Dictionary<string, List<FlowerDto>>> GetFlowersGroupedByTypeAsync();
        Task<FlowerDto> GetFlowerByIdAsync(int id);
        Task<int> AddFlowerAsync(CreateFlowerDto flowerDto, CancellationToken cancellationToken);
        Task UpdateFlowerAsync(FlowerDto flowerDto, CancellationToken cancellationToken);
        Task DeleteFlowerAsync(int id, CancellationToken cancellationToken);
    }
}
