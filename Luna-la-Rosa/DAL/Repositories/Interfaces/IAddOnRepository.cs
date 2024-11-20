using DAL.Entities;
using DAL.Helpers.Params;

namespace DAL.Repositories.Interfaces;

public interface IAddOnRepository : IGenericRepository<AddOn>
{
    Task<IQueryable<AddOn>> GetAllAddOnsAsync(AddOnParams addOnParams, IEnumerable<string> searchFields);

    // Метод для отримання подарунків за типом
    Task<Dictionary<string, List<AddOn>>> GetAddOnsGroupedByTypeAsync();
}