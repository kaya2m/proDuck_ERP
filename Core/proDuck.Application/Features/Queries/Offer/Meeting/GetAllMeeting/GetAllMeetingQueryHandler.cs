using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;

namespace proDuck.Application.Features.Queries.Proposal.Meeting.GetAllMeeting;

public class GetAllMeetingQueryHandler : IRequestHandler<GetAllMeetingQueryRequest, GetAllMeetingQueryResponse>
{
    private readonly IMeetingReadRepository _meetingReadRepository;

    public GetAllMeetingQueryHandler(IMeetingReadRepository meetingReadRepository)
    {
        _meetingReadRepository = meetingReadRepository;
    }

    public async Task<GetAllMeetingQueryResponse> Handle(GetAllMeetingQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var meetings = _meetingReadRepository.GetAll(false);

            var totalCount = await meetings.CountAsync();

            var meetingFilters = await meetings
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            return new GetAllMeetingQueryResponse
            {
                Data = meetings,
                TotalCount = totalCount,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            return new GetAllMeetingQueryResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }

    }
}
