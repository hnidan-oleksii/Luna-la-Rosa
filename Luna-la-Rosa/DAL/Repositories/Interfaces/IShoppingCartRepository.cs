using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetShoppingCartByUserId(int userId);
}