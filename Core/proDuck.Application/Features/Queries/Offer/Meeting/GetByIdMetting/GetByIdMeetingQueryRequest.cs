using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Meeting.GetByIdMetting
{
    public class GetByIdMeetingQueryRequest : IRequest<GetByIdMeetingQueryResponse>
    {
        public Guid id { get; set; }
    }
}
