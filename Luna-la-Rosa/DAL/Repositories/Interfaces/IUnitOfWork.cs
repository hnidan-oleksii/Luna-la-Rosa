namespace DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAddOnRepository AddOns { get; }
    IBouquetRepository Bouquets { get; }
    IFlowerRepository Flowers { get; }
    ICustomBouquetRepository CustomBouquets { get; }
    IShoppingCartRepository ShoppingCarts { get; }
    IOrderRepository Orders { get; }
    IUserRepository User { get; }
    Task SaveAsync();
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}
