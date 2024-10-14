using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProposalsRepositories.MeetingRepositories
{
    public class MeetingReadRepository : ReadRepository<TBL_ProposalMeeting>, IMeetingReadRepository
    {
        public MeetingReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
