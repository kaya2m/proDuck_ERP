using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Domain.Entities.Customer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.CustomerRepositories
{
    public class CustomerReadRepository : ReadRepository<TBL_Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
