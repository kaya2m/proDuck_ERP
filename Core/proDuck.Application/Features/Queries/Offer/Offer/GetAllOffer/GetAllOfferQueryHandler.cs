using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetAllMeeting;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Proposal.GetAllProposal
{
    public class GetAllProposalQueryHandler : IRequestHandler<GetAllProposalQueryRequest, GetAllProposalQueryResponse>
    {
        private readonly IProposalReadRepository _ProposalReadRepository;

        public GetAllProposalQueryHandler(IProposalReadRepository ProposalReadRepository)
        {
            _ProposalReadRepository = ProposalReadRepository;
        }

        public async Task<GetAllProposalQueryResponse> Handle(GetAllProposalQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Proposals = _ProposalReadRepository.GetAll(false);

                var totalCount = await Proposals.CountAsync();

                var ProposalFilters = await Proposals
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllProposalQueryResponse
                {
                    Data = Proposals,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new GetAllProposalQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
