using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Proposal.Proposal.CreateProposal;
using proDuck.Application.Features.Commands.Proposal.Proposal.DeleteProposal;
using proDuck.Application.Features.Commands.Proposal.Proposal.UpdateProposal;
using proDuck.Application.Features.Queries.Proposal.Proposal.GetAllProposal;
using proDuck.Application.Features.Queries.Proposal.Proposal.GetByIdProposal;


namespace proDuck.WebApi.Controllers
{
    [Route("api/Proposals")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProposalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProposalController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProposalQueryRequest getByIdProposalQueryRequest)
        {
            GetByIdProposalQueryResponse response = await _mediator.Send(getByIdProposalQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProposalQueryRequest getAllProposalQueryRequest)
        {
            GetAllProposalQueryResponse response = await _mediator.Send(getAllProposalQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProposalCommandRequest createProposalCommandRequest)
        {
            CreateProposalCommandResponse response = await _mediator.Send(createProposalCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProposalCommandRequest request)
        {
            UpdateProposalCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProposalCommandRequest request)
        {
            DeleteProposalCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
