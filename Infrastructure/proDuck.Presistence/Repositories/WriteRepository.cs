using proDuck.Application.Repositories;
using proDuck.Domain.Entities.Common;
using proDuck.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace proDuck.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly proDuckDbContext _dbContext;

    public WriteRepository(proDuckDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<T> Table => _dbContext.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        return await SaveChangesAsync() > 0;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return await SaveChangesAsync() > 0;
    }

    public bool Update(T entity)
    {
        Table.Update(entity);
        return SaveChanges() > 0;
    }

    public bool Remove(T entity)
    {
        Table.Remove(entity);
        return SaveChanges() > 0;
    }

    public bool RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
        return SaveChanges() > 0;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var entity = await Table.FindAsync(id);
        if (entity == null) return false;
        Table.Remove(entity);
        return await SaveChangesAsync() > 0;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}
