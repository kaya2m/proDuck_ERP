using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.OrderRepositories
{
    public class OrderReadRepository : ReadRepository<TBL_Order>, IOrderReadRepository
    {
        public OrderReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
