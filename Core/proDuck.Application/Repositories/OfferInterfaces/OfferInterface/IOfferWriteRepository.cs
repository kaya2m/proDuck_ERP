using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface
{
   public interface IProposalWriteRepository : IWriteRepository<TBL_Proposal>
    {
    }
}
