using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.OffersRepositories.MeetingRepositories
{
    public class MeetingReadRepository : ReadRepository<TBL_OfferMeeting>, IMeetingReadRepository
    {
        public MeetingReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
