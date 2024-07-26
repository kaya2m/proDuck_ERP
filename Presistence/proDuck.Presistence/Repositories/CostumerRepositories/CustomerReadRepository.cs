using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.CostumerRepositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICostumerReadRepository
    {
        public CustomerReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
