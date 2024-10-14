using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.ProposalDetail.GetAllProposalDetail
{
    public class GetAllProposalDetailQueryRequest : IRequest<GetAllProposalDetailQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
