using proDuck.Application.Repositories;
using proDuck.Domain.Entities.Common;
using proDuck.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories
{
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
            if(!tracking)
                query= query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
           var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query =  Table.Where(predicate);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
