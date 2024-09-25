using proDuck.Application.Repositories.ShippingAddressInterface;
using proDuck.Domain.Entities.Customer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.ShippingAddressRepositories;

public class ShippingAddressReadRepository : ReadRepository<TBL_ShippingAddress>, IShippingAddressReadRepository
{
    public ShippingAddressReadRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}