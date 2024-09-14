using proDuck.Application.Repositories.ShippingAddressInterface;
using proDuck.Domain.Entities.Customer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.ShippingAddressRepositories;

public class ShippingAddressWriteRepository : WriteRepository<TBL_ShippingAddress>, IShippingAddressWriteRepository
{
    public ShippingAddressWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
