using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Order;

namespace proDuck.Application.Repositories.OrderInterface
{
    public interface IOrderReadRepository : IReadRepository<TBL_Order>
    {
    }
}
