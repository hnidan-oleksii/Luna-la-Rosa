using BLL.DTO.Bouquet;
using DAL.Helpers;

namespace BLL.Services.Interfaces;

public interface IBouquetService
{
    Task<BouquetDto> GetBouquetByIdAsync(int id);
    PagedList<BouquetDto> GetBouquets(BouquetParams parameters);
    Task AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken);
    Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken);
    Task DeleteBouquetAsync(int id, CancellationToken cancellationToken);
}
