using AutoMapper;
using BLL.DTO.Order;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersByUserIdAsync(int userId)
    {
        var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task OrderItemsFromCartAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            _ = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(orderDto.UserId)
                ?? throw new ArgumentException("Shopping cart with given id does not exist.");

            var deliveryAddress = string.Join(", ", orderDto.DeliveryCity, orderDto.DeliveryStreet,
                orderDto.DeliveryBuilding);

            var order = new Order()
            {
                UserId = orderDto.UserId,
                Status = "Pending",
                DeliveryPrice = orderDto.DeliveryPrice,
                TotalPrice = orderDto.TotalPrice,
                DeliveryAddress = deliveryAddress,
                DeliveryDate = orderDto.DeliveryDate,
                PaymentMethod = orderDto.PaymentMethod,
                Comment = orderDto.Comment,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };
            await _unitOfWork.SaveAsync();

            var orderBouquets = new List<OrderBouquet>();
            foreach (var bouquet in orderDto.ShoppingCart.CartItems)
            {
                var orderBouquet = new OrderBouquet()
                {
                    OrderId = order.Id,
                    BouquetId = bouquet.BouquetId,
                    CustomBouquetId = bouquet.CustomBouquetId,
                    Quantity = bouquet.Quantity,
                    Price = bouquet.Price
                };
                await _unitOfWork.SaveAsync();

                var bouquetAddOns = bouquet.AddOns
                    .Select(addOn => new OrderAddOn()
                    {
                        OrderBouquetId = orderBouquet.Id,
                        AddOnId = addOn.AddOnId,
                        Quantity = addOn.Quantity,
                        CardNote = addOn.CardNote
                    })
                    .ToList();
                orderBouquet.AddOns = bouquetAddOns;
                orderBouquets.Add(orderBouquet);
            }

            order.OrderBouquets = orderBouquets;
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }


    public async Task UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var order = _mapper.Map<Order>(orderDto);
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteOrderAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.Orders.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}