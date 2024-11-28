using BLL.DTO.Bouquet;
using DAL.Helpers.Params;

namespace BlazorFront.Services.Interfaces
{
    public interface IBouquetService
    {
        Task<IEnumerable<BouquetDto>> GetAllBouquetsAsync(BouquetParams bouquetParams);
        Task<BouquetDto> GetBouquetByIdAsync(int id);
        Task<int> AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken);
        Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken);
        Task DeleteBouquetAsync(int id, CancellationToken cancellationToken);
    }
}
