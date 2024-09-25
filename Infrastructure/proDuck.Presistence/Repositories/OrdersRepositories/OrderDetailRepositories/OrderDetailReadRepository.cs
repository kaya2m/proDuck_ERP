using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.OrdersRepositories.OrderDetailRepositories;

public class OrderDetailReadRepository : ReadRepository<TBL_OrderDetails>, IOrderDetailReadRepository
{
    public OrderDetailReadRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
