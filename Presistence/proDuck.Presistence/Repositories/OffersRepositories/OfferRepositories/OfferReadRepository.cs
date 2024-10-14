using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.ProposalsRepositories.ProposalRepositories
{
    public class ProposalReadRepository : ReadRepository<TBL_Proposal>, IProposalReadRepository
    {
        public ProposalReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
