using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.OffersRepositories.OfferRepositories
{
    public class OfferReadRepository : ReadRepository<TBL_Offer>, IOfferReadRepository
    {
        public OfferReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
