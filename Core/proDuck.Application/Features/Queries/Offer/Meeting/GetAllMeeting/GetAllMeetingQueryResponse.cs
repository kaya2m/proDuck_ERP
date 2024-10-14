using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Proposal.Meeting.GetAllMeeting
{
    public class GetAllMeetingQueryResponse : ResponseDto<GetAllMeetingQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
