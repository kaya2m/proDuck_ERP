using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandRequest : IRequest<DeleteMeetingCommandResponse>
    {
        public Guid id { get; set; }
    }
}
