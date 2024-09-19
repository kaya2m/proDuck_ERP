using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OrderInterface;

namespace proDuck.Application.Features.Commands.Offer.Meeting.CreateMeeting;

public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommandRequest, CreateMeetingCommandResponse>
{
    private readonly IMeetingWriteRepository _meetingWriteRepository;

    public CreateMeetingCommandHandler(IMeetingWriteRepository meetingWriteRepository)
    {
        _meetingWriteRepository = meetingWriteRepository;
    }

    public async Task<CreateMeetingCommandResponse> Handle(CreateMeetingCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var meeting = await _meetingWriteRepository.AddAsync(new()
            {
                CustomerId = request.CustomerId,
                CommunicationType = request.CommunicationType,
                CustomerRepresentativeId = request.CustomerRepresentativeId,
                CustomerContactPerson = request.CustomerContactPerson,
                CustomerContactEmail = request.CustomerContactEmail,
                CustomerContactPhone = request.CustomerContactPhone,
                Notes = request.Notes
            });
            await _meetingWriteRepository.SaveChangesAsync();
            return new CreateMeetingCommandResponse
            {
                Data = meeting,
                Message = "Meeting created successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
            };
        }
        catch (Exception ex)
        {
            return new CreateMeetingCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult,
            };
        }


    }
}