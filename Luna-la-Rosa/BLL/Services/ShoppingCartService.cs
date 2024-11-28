using AutoMapper;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ShoppingCartDto> GetShoppingCartByUserIdAsync(int userId)
    {
        var shoppingCart = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(userId);
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<ShoppingCartDto> ChangeShoppingCartItemQuantityAsync(int shoppingCartId, int shoppingCartItemId,
        int quantity, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var shoppingCart = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(shoppingCartId);
            if (shoppingCart == null)
                throw new ArgumentException("Shopping cart with given id does not exist.");

            var shoppingCartItem = shoppingCart.CartItems.FirstOrDefault();
            if (shoppingCartItem == null)
                throw new ArgumentException("Shopping cart item with given id is not in the shopping cart.");

            shoppingCartItem.Quantity = quantity;
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

    public async Task<ShoppingCartDto> DeleteItemFromShoppingCartAsync(int shoppingCartId, int shoppingCartItemId,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var shoppingCart = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(shoppingCartId);
            if (shoppingCart == null)
                throw new ArgumentException("Shopping cart with given id does not exist.");

            var shoppingCartItem = shoppingCart.CartItems.FirstOrDefault();
            if (shoppingCartItem == null)
                throw new ArgumentException("Shopping cart item with given id is not in the shopping cart.");

            shoppingCart.CartItems = new List<CartItem>();
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
}