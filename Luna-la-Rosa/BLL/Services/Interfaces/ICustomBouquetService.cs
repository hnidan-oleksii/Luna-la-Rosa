using BLL.DTO.CustomBouquet;
using BLL.DTO.ShoppingCart;

namespace BLL.Services.Interfaces;

public interface ICustomBouquetService
{
    Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id);

    Task<ShoppingCartDto> AddCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto,
        CancellationToken cancellationToken);

    Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken);
}