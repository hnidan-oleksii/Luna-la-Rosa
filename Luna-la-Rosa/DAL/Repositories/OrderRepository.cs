using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(LunaContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await context.Orders
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.Bouquet)
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.CustomBouquet)
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.AddOns)
            .ThenInclude(ob => ob.AddOn)
            .ToListAsync();
        return orders;
    }

    public override async Task<Order> GetByIdAsync(int id)
    {
        var order = await context.Orders
                        .Include(o => o.OrderBouquets)
                        .ThenInclude(ob => ob.Bouquet)
                        .Include(o => o.OrderBouquets)
                        .ThenInclude(ob => ob.CustomBouquet)
                        .Include(o => o.OrderBouquets)
                        .ThenInclude(ob => ob.AddOns)
                        .ThenInclude(ob => ob.AddOn)
                        .FirstOrDefaultAsync(o => o.Id == id)
                    ?? throw new KeyNotFoundException($"Order with ID {id} not found.");
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await context.Orders
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.Bouquet)
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.CustomBouquet)
            .Include(o => o.OrderBouquets)
            .ThenInclude(ob => ob.AddOns)
            .ThenInclude(ob => ob.AddOn)
            .Where(o => o.UserId == userId)
            .ToListAsync();
        return orders;
    }
}