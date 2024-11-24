using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomBouquetRepository : GenericRepository<CustomBouquet>, ICustomBouquetRepository
{
    public CustomBouquetRepository(LunaContext context) : base(context)
    {
    }

    public override async Task<CustomBouquet> GetByIdAsync(int id)
    {
        var customBouquet = await context.CustomBouquets
                                .Include(cb => cb.CustomBouquetAddOns)
                                .ThenInclude(bao => bao.AddOn)
                                .Include(cb => cb.CustomBouquetFlowers)
                                .ThenInclude(cbf => cbf.Flower)
                                .FirstOrDefaultAsync(cb => cb.Id == id)
                            ?? throw new KeyNotFoundException($"CustomBouquet with ID {id} not found.");
        return customBouquet;
    }
}