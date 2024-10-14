using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.Proposal.DeleteProposal
{
    public class DeleteProposalCommandRequest : IRequest<DeleteProposalCommandResponse>
    {
        public Guid id { get; set; }
    }
}
