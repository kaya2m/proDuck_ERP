using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.ProposalDetail.DeleteProposalDetail
{
    public class DeleteProposalDetailCommandRequest : IRequest<DeleteProposalDetailCommandResponse>
    {
        public Guid id { get; set; }
    }
}
