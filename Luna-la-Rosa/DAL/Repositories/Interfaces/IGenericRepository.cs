namespace DAL.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GenerateGetAllAsync();
    Task GenerateAddAsync(T entity);
    Task GenerateUpdateAsync(T entity);
    Task GenerateDeleteAsync(T entity);
}