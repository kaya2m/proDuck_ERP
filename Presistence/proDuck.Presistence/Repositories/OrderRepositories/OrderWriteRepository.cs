using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.Repositories.InvoiceFileInterface;
using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.OrderRepositories
{
    internal class OrderWriteRepository : WriteRepository<TBL_Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
