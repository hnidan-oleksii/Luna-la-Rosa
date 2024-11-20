using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Helpers.Search;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class AddOnRepository : GenericRepository<AddOn>, IAddOnRepository
{
    private readonly ISearchHelper<AddOn> _searchHelper;

    public AddOnRepository(LunaContext context, ISearchHelper<AddOn> searchHelper) : base(context)
    {
        _searchHelper = searchHelper;
    }

    public async Task<IQueryable<AddOn>> GetAllAddOnsAsync(AddOnParams addOnParams, IEnumerable<string> searchFields)
    {
        var query = context.AddOns.AsQueryable();
        if (!string.IsNullOrWhiteSpace(addOnParams.SearchQuery))
            query = _searchHelper.ApplySearch(query, addOnParams.SearchQuery, searchFields);
        return await Task.FromResult(query);
    }

    public async Task<Dictionary<string, List<AddOn>>> GetAddOnsGroupedByTypeAsync()
    {
        var addOns = await context.AddOns
            .Include(addOn => addOn.Type)
            .Where(addOn => !addOn.IsDeleted)
            .ToListAsync();

        var groupedAddOns = addOns
            .GroupBy(addOn => addOn.Type?.Name)
            .ToDictionary(k => k.Key, g => g.ToList());

        return groupedAddOns;
    }
}