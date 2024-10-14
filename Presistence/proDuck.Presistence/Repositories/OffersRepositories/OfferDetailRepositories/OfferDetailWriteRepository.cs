using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.ProposalsRepositories.ProposalDetailRepositories;

public class ProposalDetailWriteRepository : WriteRepository<TBL_ProposalDetails>, IProposalDetailWriteRepository
{
    public ProposalDetailWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    { }
}
