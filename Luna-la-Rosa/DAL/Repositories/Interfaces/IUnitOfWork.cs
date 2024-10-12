﻿namespace DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAddOnRepository AddOns { get; }
	IBouquetRepository Bouquets { get; }
    Task SaveAsync();
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}
