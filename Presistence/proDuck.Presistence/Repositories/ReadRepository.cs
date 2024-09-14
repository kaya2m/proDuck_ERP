using proDuck.Application.Repositories;
using proDuck.Domain.Entities.Common;
using proDuck.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace proDuck.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly proDuckDbContext _dbContext;

    public ReadRepository(proDuckDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    DbSet<T> Table => _dbContext.Set<T>();

    DbSet<T> IRepository<T>.Table => _dbContext.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<IQueryable<T>> GetAllAsync(bool tracking = true)
    {
        var query = await Task.Run(() => GetAll(tracking));
        return query;
    }

    public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
    {
        var query = Table.Where(predicate);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
    {
        var query = await Task.Run(() => GetWhere(predicate, tracking));
        return query;
    }
}
