using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
namespace proDuck.Application.Features.Queries.Proposal.Meeting.GetByIdMetting;

public class GetByIdMeetingQueryHandler : IRequestHandler<GetByIdMeetingQueryRequest, GetByIdMeetingQueryResponse>
{
    private readonly IMeetingReadRepository _meetingReadRepository;

    public GetByIdMeetingQueryHandler(IMeetingReadRepository meetingReadRepository)
    {
        _meetingReadRepository = meetingReadRepository;
    }

    public async Task<GetByIdMeetingQueryResponse> Handle(GetByIdMeetingQueryRequest request, CancellationToken cancellationToken)
    {
        var meeting = await _meetingReadRepository.GetByIdAsync(request.id, false);
        var isSuccessful = meeting != null;

        return new GetByIdMeetingQueryResponse
        {
            Data = meeting,
            IsSuccessful = isSuccessful,
            StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
        };
    }
}
