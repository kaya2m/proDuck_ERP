using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.ProductCard.ProductCard.CreateProductCard;
using proDuck.Application.Features.Commands.ProductCard.ProductCard.DeleteProductCard;
using proDuck.Application.Features.Commands.ProductCard.ProductCard.UpdateProductCard;
using proDuck.Application.Features.Queries.ProductCard.ProductCard.GetAllProduct;
using proDuck.Application.Features.Queries.ProductCard.ProductCard.GetByIdProduct;

namespace proDuck.WebApi.Controllers
{
    [Route("api/productCard")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductCardQueryRequest getByIdProductCardQueryRequest)
        {
            GetByIdProductCardQueryResponse response = await _mediator.Send(getByIdProductCardQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductCardQueryRequest getAllProductCardQueryRequest)
        {
            GetAllProductCardQueryResponse response = await _mediator.Send(getAllProductCardQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCardCommandRequest createProductCardCommandRequest)
        {
            CreateProductCardCommandResponse response = await _mediator.Send(createProductCardCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCardCommandRequest request)
        {
            UpdateProductCardCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCardCommandRequest request)
        {
            DeleteProductCardCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
