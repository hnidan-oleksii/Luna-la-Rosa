namespace DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}