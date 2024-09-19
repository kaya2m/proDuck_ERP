using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.OffersRepositories.OfferDetailRepositories;

public class OfferDetailReadRepository : ReadRepository<TBL_OfferDetails>, IOfferDetailReadRepository
{
    public OfferDetailReadRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
