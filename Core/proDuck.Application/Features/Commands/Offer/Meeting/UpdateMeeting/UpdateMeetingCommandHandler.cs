using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.Meeting.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommandRequest, UpdateMeetingCommandResponse>
    {
        public Task<UpdateMeetingCommandResponse> Handle(UpdateMeetingCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
