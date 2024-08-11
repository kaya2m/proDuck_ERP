using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Domain.Entities.Customer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.CustomerRepositories;

public class CustomerWriteRepository : WriteRepository<TBL_Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
