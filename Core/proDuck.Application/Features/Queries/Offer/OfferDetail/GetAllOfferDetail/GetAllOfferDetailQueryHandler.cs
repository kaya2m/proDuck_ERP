using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetAllMeeting;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.ProposalDetail.GetAllProposalDetail
{
    public class GetAllProposalDetailQueryHandler : IRequestHandler<GetAllProposalDetailQueryRequest, GetAllProposalDetailQueryResponse>
    {
        private readonly IProposalDetailReadRepository _ProposalDetailReadRepository;

        public GetAllProposalDetailQueryHandler(IProposalDetailReadRepository ProposalDetailReadRepository)
        {
            _ProposalDetailReadRepository = ProposalDetailReadRepository;
        }

        public async Task<GetAllProposalDetailQueryResponse> Handle(GetAllProposalDetailQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ProposalDetails = _ProposalDetailReadRepository.GetAll(false);

                var totalCount = await ProposalDetails.CountAsync();

                var ProposalDetailFilters = await ProposalDetails
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllProposalDetailQueryResponse
                {
                    Data = ProposalDetails,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new GetAllProposalDetailQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
