using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Offer.Offer.CreateOffer;
using proDuck.Application.Features.Commands.Offer.Offer.DeleteOffer;
using proDuck.Application.Features.Commands.Offer.Offer.UpdateOffer;
using proDuck.Application.Features.Queries.Offer.Offer.GetAllOffer;
using proDuck.Application.Features.Queries.Offer.Offer.GetByIdOffer;


namespace proDuck.WebApi.Controllers
{
    [Route("api/offers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdOfferQueryRequest getByIdOfferQueryRequest)
        {
            GetByIdOfferQueryResponse response = await _mediator.Send(getByIdOfferQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllOfferQueryRequest getAllOfferQueryRequest)
        {
            GetAllOfferQueryResponse response = await _mediator.Send(getAllOfferQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateOfferCommandRequest createOfferCommandRequest)
        {
            CreateOfferCommandResponse response = await _mediator.Send(createOfferCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOfferCommandRequest request)
        {
            UpdateOfferCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOfferCommandRequest request)
        {
            DeleteOfferCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
