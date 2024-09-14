using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking=true);
        Task<IQueryable<T>> GetAllAsync(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate,bool tracking=true);
        Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
