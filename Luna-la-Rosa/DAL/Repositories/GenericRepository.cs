using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected readonly LunaContext context;

    public GenericRepository(LunaContext context)
    {
        this.context = context;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
    
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
    
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() => context.Set<T>().Update(entity));
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => context.Set<T>().Remove(entity));
    }
}