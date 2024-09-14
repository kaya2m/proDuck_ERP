using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        Task<bool> RemoveAsync(Guid id);
        bool Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
