using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Proposal.GetAllProposal
{
    public class GetAllProposalQueryResponse : ResponseDto<GetAllProposalQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
