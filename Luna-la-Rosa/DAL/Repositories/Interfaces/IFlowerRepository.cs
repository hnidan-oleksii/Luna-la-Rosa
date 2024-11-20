using DAL.Entities;
using DAL.Helpers.Params;

namespace DAL.Repositories.Interfaces;

public interface IFlowerRepository : IGenericRepository<Flower>
{
    Task<List<Flower>> GetAllFlowersAsync(FlowerParams flowerParams, IEnumerable<string> searchFields);
    Task<Dictionary<string, List<Flower>>> GetFlowersGroupedByTypeAsync();
}