using BLL.DTO.CustomBouquet;

namespace BLL.Services.Interfaces;

public interface ICustomBouquetService
{
    Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id);
    Task<int> AddCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto, CancellationToken cancellationToken);
    Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken);
}
