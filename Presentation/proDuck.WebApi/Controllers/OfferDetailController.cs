using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Proposal.ProposalDetail.CreateProposalDetail;
using proDuck.Application.Features.Commands.Proposal.ProposalDetail.DeleteProposalDetail;
using proDuck.Application.Features.Commands.Proposal.ProposalDetail.UpdateProposalDetail;
using proDuck.Application.Features.Queries.Proposal.ProposalDetail.GetAllProposalDetail;
using proDuck.Application.Features.Queries.Proposal.ProposalDetail.GetByIdProposalDetail;


namespace proDuck.WebApi.Controllers
{
    [Route("api/ProposalDetails")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProposalDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProposalDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProposalDetailQueryRequest getByIdProposalDetailQueryRequest)
        {
            GetByIdProposalDetailQueryResponse response = await _mediator.Send(getByIdProposalDetailQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProposalDetailQueryRequest getAllProposalDetailQueryRequest)
        {
            GetAllProposalDetailQueryResponse response = await _mediator.Send(getAllProposalDetailQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProposalDetailCommandRequest createProposalDetailCommandRequest)
        {
            CreateProposalDetailCommandResponse response = await _mediator.Send(createProposalDetailCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProposalDetailCommandRequest request)
        {
            UpdateProposalDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProposalDetailCommandRequest request)
        {
            DeleteProposalDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
