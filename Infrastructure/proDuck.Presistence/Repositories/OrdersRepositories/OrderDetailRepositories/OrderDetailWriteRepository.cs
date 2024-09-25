using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.OrdersRepositories.OrderDetailRepositories
{
    public class OrderDetailWriteRepository : WriteRepository<TBL_OrderDetails>, IOrderDetailWriteRepository
    {
        public OrderDetailWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
