﻿using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LunaContext _context;
    private IDbContextTransaction _transaction;

    public IAddOnRepository AddOns { get; }
    public IBouquetRepository Bouquets { get; }

    public UnitOfWork(LunaContext context,
        IAddOnRepository addOns,
        IBouquetRepository bouquetRepository)
    {
        _context = context;
        AddOns = addOns;
        Bouquets = bouquetRepository;
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }
}