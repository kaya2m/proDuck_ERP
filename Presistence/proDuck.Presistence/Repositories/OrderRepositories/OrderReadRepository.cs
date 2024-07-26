using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.OrderRepositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
