using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetByIdMetting;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Proposal.GetByIdProposal
{
    public class GetByIdProposalQueryHandler : IRequestHandler<GetByIdProposalQueryRequest, GetByIdProposalQueryResponse>
    {
        private readonly IProposalReadRepository _ProposalReadRepository;

        public GetByIdProposalQueryHandler(IProposalReadRepository ProposalReadRepository)
        {
            _ProposalReadRepository = ProposalReadRepository;
        }

        public async Task<GetByIdProposalQueryResponse> Handle(GetByIdProposalQueryRequest request, CancellationToken cancellationToken)
        {
            var Proposal = await _ProposalReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = Proposal != null;

            return new GetByIdProposalQueryResponse
            {
                Data = Proposal,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
