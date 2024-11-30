using BLL.DTO.Order;
using BLL.DTO.ShoppingCart;

namespace BLL.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<IEnumerable<OrderDto>> GetAllOrdersByUserIdAsync(int userId);
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task OrderItemsFromCartAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);
    Task UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken);
    Task DeleteOrderAsync(int id, CancellationToken cancellationToken);
}