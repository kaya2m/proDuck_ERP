using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetByIdMetting;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.ProposalDetail.GetByIdProposalDetail
{
    public class GetByIdProposalDetailQueryHandler : IRequestHandler<GetByIdProposalDetailQueryRequest, GetByIdProposalDetailQueryResponse>
    {
        private readonly IProposalDetailReadRepository _ProposalDetailReadRepository;

        public GetByIdProposalDetailQueryHandler(IProposalDetailReadRepository ProposalDetailReadRepository)
        {
            _ProposalDetailReadRepository = ProposalDetailReadRepository;
        }

        public async Task<GetByIdProposalDetailQueryResponse> Handle(GetByIdProposalDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var ProposalDetail = await _ProposalDetailReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = ProposalDetail != null;

            return new GetByIdProposalDetailQueryResponse
            {
                Data = ProposalDetail,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
