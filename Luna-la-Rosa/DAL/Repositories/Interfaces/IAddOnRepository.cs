using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAddOnRepository : IGenericRepository<AddOn>
{
    // Метод для отримання подарунків за типом
    Task<Dictionary<string, List<AddOn>>> GetAddOnsGroupedByTypeAsync();
}