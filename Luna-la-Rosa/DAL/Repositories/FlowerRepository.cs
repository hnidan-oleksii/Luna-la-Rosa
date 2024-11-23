using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Helpers.Search;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class FlowerRepository : GenericRepository<Flower>, IFlowerRepository
{
    private readonly ISearchHelper<Flower> _searchHelper;

    public FlowerRepository(LunaContext context, ISearchHelper<Flower> searchHelper) : base(context)
    {
        _searchHelper = searchHelper;
    }

    public async Task<List<Flower>> GetAllFlowersAsync(FlowerParams flowerParams, IEnumerable<string> searchFields)
    {
        var flowers = context.Flowers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(flowerParams.SearchQuery))
            flowers = _searchHelper.ApplySearch(flowers, flowerParams.SearchQuery, searchFields);
        return await flowers.ToListAsync();
    }

    public async Task<Dictionary<string, List<Flower>>> GetFlowersGroupedByTypeAsync()
    {
        var flowers = await context.Flowers
            .Include(f => f.Type)
            .Where(f => !f.IsDeleted)
            .ToListAsync();

        var groupedFlowers = flowers
            .GroupBy(f => f.Type!.Name)
            .ToDictionary(g => g.Key, g => g.ToList());

        return groupedFlowers;
    }
}