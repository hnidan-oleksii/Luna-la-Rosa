using BLL.DTO.Bouquet;
using BLL.DTO.ItemAddOn;
using BLL.DTO.ShoppingCart;
using DAL.Helpers;
using DAL.Helpers.Params;

namespace BLL.Services.Interfaces;

public interface IBouquetService
{
    Task<BouquetDto> GetBouquetByIdAsync(int id);
    PagedList<BouquetDto> GetBouquets(BouquetParams parameters);
    Task<int> AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken);
    Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken);
    Task DeleteBouquetAsync(int id, CancellationToken cancellationToken);

    Task<ShoppingCartDto> AddBouquetToCartAsync(int bouquetId, IEnumerable<ItemAddOnDto> addOns, int userId,
        CancellationToken cancellationToken);
}