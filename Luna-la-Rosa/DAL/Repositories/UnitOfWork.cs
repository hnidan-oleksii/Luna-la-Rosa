using DAL.Context;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LunaContext _context;

    public UnitOfWork(LunaContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}