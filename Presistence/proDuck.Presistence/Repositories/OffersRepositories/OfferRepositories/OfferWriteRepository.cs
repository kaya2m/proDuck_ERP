using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProposalsRepositories.ProposalRepositories
{
    public class ProposalWriteRepository : WriteRepository<TBL_Proposal>, IProposalWriteRepository
    {
        public ProposalWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        { }
    }
}
