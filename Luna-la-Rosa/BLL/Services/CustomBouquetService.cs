using AutoMapper;
using BLL.DTO.CustomBouquet;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class CustomBouquetService : ICustomBouquetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomBouquetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id)
    {
        var customBouquet = await _unitOfWork.CustomBouquets.GetByIdAsync(id);
        return _mapper.Map<CustomBouquetDto>(customBouquet);
    }

    public async Task<ShoppingCartDto> AddCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var customBouquet = _mapper.Map<CustomBouquet>(customBouquetDto);
            await _unitOfWork.CustomBouquets.AddAsync(customBouquet);
            await _unitOfWork.SaveAsync();

            foreach (var flower in customBouquetDto.CustomBouquetFlowers)
                flower.BouquetId = customBouquet.Id;
            foreach (var addOn in customBouquetDto.CustomBouquetAddOns)
                addOn.CustomBouquetId = customBouquet.Id;
            customBouquet.CustomBouquetFlowers =
                _mapper.Map<IEnumerable<CustomBouquetFlower>>(customBouquetDto.CustomBouquetFlowers);
            customBouquet.CustomBouquetAddOns =
                _mapper.Map<IEnumerable<BouquetAddOn>>(customBouquetDto.CustomBouquetAddOns);
            await _unitOfWork.CustomBouquets.UpdateAsync(customBouquet);

            var shoppingCart = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(customBouquet.UserId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    UserId = customBouquet.UserId,
                    CreatedAt = customBouquet.CreatedAt
                };
                await _unitOfWork.ShoppingCarts.AddAsync(shoppingCart);
                await _unitOfWork.SaveAsync();
            }

            var cartItem = new CartItem()
            {
                CartId = shoppingCart.UserId,
                BouquetId = null,
                CustomBouquetId = customBouquet.Id,
                Quantity = 1,
                Price = customBouquet.TotalPrice
            };
            await _unitOfWork.SaveAsync();
            var cartItemAddOns = customBouquetDto.CustomBouquetAddOns
                .Select(addOn => new CartItemAddOn()
                {
                    CartItemId = cartItem.Id,
                    AddOnId = addOn.Id,
                    Quantity = addOn.Quantity,
                    CardNote = addOn.CardNote
                })
                .ToList();
            cartItem.AddOns = cartItemAddOns;

            var cartItems = shoppingCart.CartItems.ToList();
            cartItems.Add(cartItem);
            shoppingCart.CartItems = cartItems;
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return _mapper.Map<ShoppingCartDto>(shoppingCart);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var customBouquet = _mapper.Map<CustomBouquet>(customBouquetDto);
            customBouquet.TotalPrice =
                CalculateTotalPrice(customBouquet.CustomBouquetFlowers, customBouquet.CustomBouquetAddOns);
            await _unitOfWork.CustomBouquets.UpdateAsync(customBouquet);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    private static decimal CalculateTotalPrice(IEnumerable<CustomBouquetFlower> flowers,
        IEnumerable<BouquetAddOn> addOns)
    {
        var itemAddOnDtos = addOns.ToList();

        var totalPrice = flowers.Sum(f => f.Quantity * f.Flower.Price);
        if (itemAddOnDtos.Count != 0)
            totalPrice += itemAddOnDtos.Sum(ao => ao.Quantity * ao.AddOn.Price);

        return totalPrice;
    }
}