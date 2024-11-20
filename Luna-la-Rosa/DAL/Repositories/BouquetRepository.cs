using DAL.Helpers;
using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Filtering;
using DAL.Helpers.Search;
using DAL.Helpers.Sorting;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BouquetRepository : GenericRepository<Bouquet>, IBouquetRepository
{
    private readonly ISortHelper<Bouquet> _sortHelper;
    private readonly ISearchHelper<Bouquet> _searchHelper;

    public BouquetRepository(LunaContext context, ISortHelper<Bouquet> sortHelper, ISearchHelper<Bouquet> searchHelper)
        : base(context)
    {
        _sortHelper = sortHelper;
        _searchHelper = searchHelper;
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

    public PagedList<Bouquet> GetBouquets(BouquetParams parameters, IEnumerable<string> searchFields)
    {
        var bouquets = GetCategorizedBouquets();

        ApplyFilters(ref bouquets, parameters);

        if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
        {
            bouquets = _searchHelper.ApplySearch(bouquets, parameters.SearchQuery, searchFields);
        }

        var sortedBouquets = _sortHelper.ApplySort(bouquets, parameters.OrderBy);

        return PagedList<Bouquet>.ToPagedList(
            sortedBouquets,
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

    private static void ApplyFilters(ref IQueryable<Bouquet> bouquets, BouquetParams parameters)
    {
        var predicate = PredicateBuilder.True<Bouquet>();

        if (parameters.MinPrice > 0 || parameters.MaxPrice > 0)
        {
            predicate = predicate.And(b =>
                b.Price >= (parameters.MinPrice > 0 ? parameters.MinPrice : b.Price) &&
                b.Price <= (parameters.MaxPrice > 0 ? parameters.MaxPrice : b.Price));
        }

        if (!string.IsNullOrWhiteSpace(parameters.Size))
        {
            predicate = predicate.And(b => b.Size == parameters.Size);
        }

        if (!string.IsNullOrWhiteSpace(parameters.MainColor))
        {
            predicate = predicate.And(b => b.MainColor == parameters.MainColor);
        }

        if (!string.IsNullOrWhiteSpace(parameters.FlowerTypeNames))
        {
            var flowersSplit = parameters.FlowerTypeNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            predicate = predicate.And(b =>
                b.BouquetFlowers.Select(bf => bf.Flower.Name).Any(f => flowersSplit.Contains(f)));
        }

        if (!string.IsNullOrWhiteSpace(parameters.BouquetCategories))
        {
            var categoriesSplit = parameters.BouquetCategories
                .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            predicate = predicate.And(b =>
                b.BouquetCategories.Select(bc => bc.Category.CategoryName).Any(c => categoriesSplit.Contains(c)));
        }

        bouquets = bouquets.Where(predicate);
    }
}