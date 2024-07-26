using proDuck.Application.Repositories;
using proDuck.Domain.Entities.Common;
using proDuck.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories
{
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
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
           await Table.AddRangeAsync(entity);
            return true;
        }
        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry =  Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }
        public async Task<bool> Remove(string id)
        {
         T entity= await Table.FirstOrDefaultAsync(Table => Table.Id == Guid.Parse(id));
           return Remove(entity);
        }

        public async Task<int> SaveAsync()
        => await _dbContext.SaveChangesAsync();

    }
}
