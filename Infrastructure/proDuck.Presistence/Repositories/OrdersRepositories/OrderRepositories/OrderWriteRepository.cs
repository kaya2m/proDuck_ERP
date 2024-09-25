using proDuck.Application.Repositories.OrderInterface.Order;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.OrdersRepositories.OrderRepositories;

public class OrderWriteRepository : WriteRepository<TBL_Order>, IOrderWriteRepository
{
    public OrderWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
