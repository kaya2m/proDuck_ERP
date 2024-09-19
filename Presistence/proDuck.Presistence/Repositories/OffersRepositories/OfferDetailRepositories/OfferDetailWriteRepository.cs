using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.OffersRepositories.OfferDetailRepositories;

public class OfferDetailWriteRepository : WriteRepository<TBL_OfferDetails>, IOfferDetailWriteRepository
{
    public OfferDetailWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    { }
}
