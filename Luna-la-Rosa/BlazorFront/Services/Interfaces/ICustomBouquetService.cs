using BLL.DTO.CustomBouquet;
using BLL.DTO.ShoppingCart;

namespace BlazorFront.Services.Interfaces
{
    public interface ICustomBouquetService
    {
        Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id);
        Task<ShoppingCartDto> CreateCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto, CancellationToken cancellationToken);
        Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken);
    }
}
