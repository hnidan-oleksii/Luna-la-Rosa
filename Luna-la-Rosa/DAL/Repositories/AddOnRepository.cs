using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class AddOnRepository : GenericRepository<AddOn>, IAddOnRepository
{
    public AddOnRepository(LunaContext context) : base(context)
    {
    }

    public async Task<Dictionary<string, List<AddOn>>> GetAddOnsGroupedByTypeAsync()
    {
        var addOns = await GetAllAsync();
        var groupedAddOns = addOns
            .GroupBy(addOn => addOn.Type)
            .ToDictionary(k => k.Key, g => g.ToList());

        return groupedAddOns;
    }
}