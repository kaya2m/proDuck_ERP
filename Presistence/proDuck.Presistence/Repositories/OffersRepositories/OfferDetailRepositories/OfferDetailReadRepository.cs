using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.ProposalsRepositories.ProposalDetailRepositories;

public class ProposalDetailReadRepository : ReadRepository<TBL_ProposalDetails>, IProposalDetailReadRepository
{
    public ProposalDetailReadRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
