using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;

namespace proDuck.Application.Features.Commands.Proposal.Meeting.DeleteMeeting;

public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommandRequest, DeleteMeetingCommandResponse>
{
    private readonly IMeetingWriteRepository _meetingWriteRepository;
    private readonly IMeetingReadRepository _meetingReadRepository;

    public DeleteMeetingCommandHandler(IMeetingWriteRepository meetingWriteRepository, IMeetingReadRepository meetingReadRepository)
    {
        _meetingWriteRepository = meetingWriteRepository;
        _meetingReadRepository = meetingReadRepository;
    }

    public async Task<DeleteMeetingCommandResponse> Handle(DeleteMeetingCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var meetingInfo = _meetingReadRepository.GetByIdAsync(request.id).Result;
            meetingInfo.Status = false;
            _meetingWriteRepository.Update(meetingInfo);
            var meeting = await _meetingWriteRepository.SaveChangesAsync();
            return new DeleteMeetingCommandResponse
            {
                Message = "Meeting deleted successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            return new DeleteMeetingCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }
    }
}
