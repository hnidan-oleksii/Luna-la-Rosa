using AutoMapper;
using BLL.DTO.Bouquet;
using BLL.DTO.BouquetCategoryBouquet;
using BLL.DTO.ItemAddOn;
using BLL.DTO.ShoppingCart;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using DAL.Helpers.Params;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class BouquetService : IBouquetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BouquetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BouquetDto> GetBouquetByIdAsync(int id)
    {
        return _mapper.Map<BouquetDto>(await _unitOfWork.Bouquets.GetByIdAsync(id));
    }

    public PagedList<BouquetDto> GetBouquets(BouquetParams parameters)
    {
        var searchFields = new List<string> { "Name" };
        var bouquets = _unitOfWork.Bouquets.GetBouquets(parameters, searchFields);
        return _mapper.Map<PagedList<BouquetDto>>(bouquets);
    }

    public async Task<int> AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var bouquet = _mapper.Map<Bouquet>(bouquetDto);

            bouquet.CreatedAt = DateTime.Now.ToUniversalTime();
            bouquet.Price = bouquetDto.Flowers.Sum(f => f.Quantity * f.Flower.Price);
            if (bouquetDto.AddOns.Count != 0)
                bouquet.Price += bouquetDto.AddOns.Sum(ao => ao.Quantity * ao.AddOn.Price);

            await _unitOfWork.Bouquets.AddAsync(bouquet);
            await _unitOfWork.SaveAsync();
            Console.WriteLine(bouquet.Id);

            foreach (var flower in bouquetDto.Flowers)
                flower.BouquetId = bouquet.Id;
            foreach (var addOn in bouquetDto.AddOns)
                addOn.BouquetId = bouquet.Id;
            foreach (var category in bouquetDto.Categories)
                category.BouquetId = bouquet.Id;

            bouquet.BouquetCategories = _mapper.Map<IEnumerable<BouquetCategoryBouquet>>(bouquetDto.Categories);
            bouquet.BouquetAddOns = _mapper.Map<IEnumerable<BouquetAddOn>>(bouquetDto.AddOns);
            bouquet.BouquetFlowers = _mapper.Map<IEnumerable<BouquetFlower>>(bouquetDto.Flowers);
            await _unitOfWork.Bouquets.UpdateAsync(bouquet);

            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return bouquet.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var bouquet = _mapper.Map<Bouquet>(bouquetDto);
            bouquet.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _unitOfWork.Bouquets.UpdateAsync(bouquet);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteBouquetAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.Bouquets.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task<ShoppingCartDto> AddBouquetToCartAsync(int bouquetId, IEnumerable<ItemAddOnDto> addOns,
        int userId, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var bouquet = await _unitOfWork.Bouquets.GetByIdAsync(bouquetId);

            var shoppingCart = await _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    UserId = userId,
                    CreatedAt = DateTime.Now.ToUniversalTime()
                };
                await _unitOfWork.ShoppingCarts.AddAsync(shoppingCart);
                await _unitOfWork.SaveAsync();
            }

            var cartItem = new CartItem()
            {
                CartId = shoppingCart.UserId,
                BouquetId = bouquetId,
                CustomBouquetId = null,
                Quantity = 1,
                Price = bouquet.Price
            };
            await _unitOfWork.SaveAsync();

            var cartItemAddOns = addOns
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
}