using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Proposal.Meeting.CreateMeeting;
using proDuck.Application.Features.Commands.Proposal.Meeting.DeleteMeeting;
using proDuck.Application.Features.Commands.Proposal.Meeting.UpdateMeeting;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetAllMeeting;
using proDuck.Application.Features.Queries.Proposal.Meeting.GetByIdMetting;

namespace proDuck.WebApi.Controllers
{
    [Route("api/meetings")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdMeetingQueryRequest getByIdMeetingQueryRequest)
        {
            GetByIdMeetingQueryResponse response = await _mediator.Send(getByIdMeetingQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllMeetingQueryRequest getAllMeetingQueryRequest)
        {
            GetAllMeetingQueryResponse response = await _mediator.Send(getAllMeetingQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMeetingCommandRequest createMeetingCommandRequest)
        {
            CreateMeetingCommandResponse response = await _mediator.Send(createMeetingCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMeetingCommandRequest request)
        {
            UpdateMeetingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMeetingCommandRequest request)
        {
            DeleteMeetingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
