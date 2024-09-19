using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;

namespace proDuck.Application.Features.Commands.Offer.Meeting.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommandRequest, UpdateMeetingCommandResponse>
    {
        private readonly IMeetingWriteRepository _meetingWriteRepository;
        private readonly IMeetingReadRepository _meetingReadRepository;

        public UpdateMeetingCommandHandler(IMeetingWriteRepository meetingWriteRepository, IMeetingReadRepository meetingReadRepository)
        {
            _meetingWriteRepository = meetingWriteRepository;
            _meetingReadRepository = meetingReadRepository;
        }

        public async Task<UpdateMeetingCommandResponse> Handle(UpdateMeetingCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TBL_OfferMeeting meeting = await _meetingReadRepository.GetByIdAsync(request.id);

                if (meeting == null)
                {
                    return new UpdateMeetingCommandResponse
                    {
                        Message = "Meeting not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                meeting.CustomerId = request.CustomerId;
                meeting.CommunicationType = request.CommunicationType;
                meeting.CustomerContactPerson = request.CustomerContactPerson;
                meeting.CustomerContactEmail = request.CustomerContactEmail;
                meeting.CustomerContactPhone = request.CustomerContactPhone;
                meeting.Notes = request.Notes;
                _meetingWriteRepository.Update(meeting);
                await _meetingWriteRepository.SaveChangesAsync();

                return new UpdateMeetingCommandResponse
                {
                    Message = "Meeting updated successfully",
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status204NoContent,
                };
            }
            catch (Exception ex)
            {
                return new UpdateMeetingCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                };
            }

        }
    }
}
