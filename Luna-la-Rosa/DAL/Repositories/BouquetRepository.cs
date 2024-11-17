using DAL.Helpers;
using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Sorting;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BouquetRepository : GenericRepository<Bouquet>, IBouquetRepository
{
    private ISortHelper<Bouquet> _sortHelper;

    public BouquetRepository(LunaContext context, ISortHelper<Bouquet> sortHelper) : base(context)
    {
        _sortHelper = sortHelper;
    }

    public override async Task<Bouquet> GetByIdAsync(int id)
    {
        var bouquet = await context.Bouquets
            .Include(b => b.BouquetCategories)
            .Include(b => b.BouquetFlowers)
            .Include(b => b.BouquetAddOns)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        if (bouquet == null)
        {
            throw new KeyNotFoundException($"Bouquet with ID {id} not found.");
        }

        return bouquet;
    }

    public PagedList<Bouquet> GetBouquets(BouquetParams parameters)
    {
        var bouquets = GetCategorizedBouquets();
        bouquets = bouquets.Where(b => b.Price >= parameters.MinPrice
                                       && b.Price <= parameters.MaxPrice
                                       && b.Size == parameters.Size
                                       && b.MainColor == parameters.MainColor
                                       && GetBouquetFlowersFilter(b, parameters.FlowerTypeNames)
                                       && GetBouquetCategoryFilter(b, parameters.BouquetCategories)
        );

        _sortHelper.ApplySort(bouquets, parameters.OrderBy);

        return PagedList<Bouquet>.ToPagedList(
            bouquets,
            parameters.PageNumber,
            parameters.PageSize
        );
    }

    private IQueryable<Bouquet> GetCategorizedBouquets()
    {
        return context.Bouquets
            .Include(b => b.BouquetCategories)
            .Include(b => b.BouquetFlowers)
            .Include(b => b.BouquetAddOns)
            .AsNoTracking();
    }

    private bool GetBouquetCategoryFilter(Bouquet bouquet, string bouquetCategories)
    {
        var categoriesSplit = bouquetCategories.Split(",",
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        return bouquet.BouquetCategories == null
               || bouquet.BouquetCategories
                   .Select(bc => bc.Category.CategoryName)
                   .Any(bdn => categoriesSplit.Contains(bdn));
    }

    private bool GetBouquetFlowersFilter(Bouquet bouquet, string bouquetFlowers)
    {
        var flowersSplit = bouquetFlowers.Split(",",
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        return bouquet.BouquetFlowers
            .Select(bf => bf.Flower.Name)
            .Any(bfn => flowersSplit.Contains(bfn));
    }
}