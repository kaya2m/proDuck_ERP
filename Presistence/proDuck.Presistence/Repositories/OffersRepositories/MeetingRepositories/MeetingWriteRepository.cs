using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.ProposalsRepositories.MeetingRepositories;

public class MeetingWriteRepository : WriteRepository<TBL_ProposalMeeting>, IMeetingWriteRepository
{
    public MeetingWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
