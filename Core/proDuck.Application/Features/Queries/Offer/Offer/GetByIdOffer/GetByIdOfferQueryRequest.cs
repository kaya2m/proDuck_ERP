using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Proposal.GetByIdProposal
{
    public class GetByIdProposalQueryRequest: IRequest<GetByIdProposalQueryResponse>
    {
        public Guid id { get; set; }
    }
}
