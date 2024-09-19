using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.OffersRepositories.MeetingRepositories;

public class MeetingWriteRepository : WriteRepository<TBL_OfferMeeting>, IMeetingWriteRepository
{
    public MeetingWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
