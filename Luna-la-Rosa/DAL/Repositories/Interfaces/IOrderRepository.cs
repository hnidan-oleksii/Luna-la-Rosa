using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
}