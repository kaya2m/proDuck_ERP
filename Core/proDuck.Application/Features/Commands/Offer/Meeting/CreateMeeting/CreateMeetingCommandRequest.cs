using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.Meeting.CreateMeeting
{
    public class CreateMeetingCommandRequest : IRequest<CreateMeetingCommandResponse>
    {
        public Guid CustomerId { get; set; }
        public string CommunicationType { get; set; }
        public Guid CustomerRepresentativeId { get; set; }
        public string CustomerContactPerson { get; set; }
        public string CustomerContactEmail { get; set; }
        public string CustomerContactPhone { get; set; }
        public string Notes { get; set; }
    }
}
