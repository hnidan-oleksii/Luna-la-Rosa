using DAL.Entities;
using DAL.Helpers.Params;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IQueryable<User>> GetAllUserAsync(UserParams userParams, IEnumerable<string> searchFields);
}
