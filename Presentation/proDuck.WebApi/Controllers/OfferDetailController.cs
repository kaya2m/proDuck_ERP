using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Offer.OfferDetail.CreateOfferDetail;
using proDuck.Application.Features.Commands.Offer.OfferDetail.DeleteOfferDetail;
using proDuck.Application.Features.Commands.Offer.OfferDetail.UpdateOfferDetail;
using proDuck.Application.Features.Queries.Offer.OfferDetail.GetAllOfferDetail;
using proDuck.Application.Features.Queries.Offer.OfferDetail.GetByIdOfferDetail;


namespace proDuck.WebApi.Controllers
{
    [Route("api/offerDetails")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OfferDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdOfferDetailQueryRequest getByIdOfferDetailQueryRequest)
        {
            GetByIdOfferDetailQueryResponse response = await _mediator.Send(getByIdOfferDetailQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllOfferDetailQueryRequest getAllOfferDetailQueryRequest)
        {
            GetAllOfferDetailQueryResponse response = await _mediator.Send(getAllOfferDetailQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateOfferDetailCommandRequest createOfferDetailCommandRequest)
        {
            CreateOfferDetailCommandResponse response = await _mediator.Send(createOfferDetailCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOfferDetailCommandRequest request)
        {
            UpdateOfferDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOfferDetailCommandRequest request)
        {
            DeleteOfferDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
