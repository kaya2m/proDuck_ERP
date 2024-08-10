using proDuck.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.CustomerInterface
{
    public interface ICustomerReadRepository : IReadRepository<TBL_Customer>
    {
    }
}
