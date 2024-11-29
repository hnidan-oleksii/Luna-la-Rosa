using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ShoppingCartRepisitory : GenericRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepisitory(LunaContext context) : base(context)
    {
    }

    public async Task<ShoppingCart?> GetShoppingCartByUserId(int userId)
    {
        var shoppingCart = await context.ShoppingCarts
            .Include(sc => sc.CartItems)
            .ThenInclude(ca => ca.AddOns)
            .ThenInclude(cao => cao.AddOn)
            .FirstOrDefaultAsync(sc => sc.UserId == userId);
        return shoppingCart;
    }
}