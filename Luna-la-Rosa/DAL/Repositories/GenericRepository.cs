using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenericRepository<T>(LunaContext context) : IGenericRepository<T>
    where T : class
{
    public async Task<T> GenerateGetByIdAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
    
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
    
        return entity;
    }

    public async Task<IEnumerable<T>> GenerateGetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task GenerateAddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task GenerateUpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task GenerateDeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}