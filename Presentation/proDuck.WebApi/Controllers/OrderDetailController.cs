using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Commands.Order.OrderDetail.CreateOrderDetail;
using proDuck.Application.Features.Commands.Order.OrderDetail.DeleteOrderDetail;
using proDuck.Application.Features.Commands.Order.OrderDetail.UpdateOrderDetail;
using proDuck.Application.Features.Queries.Order.OrderDetail.GetAllOrderDetail;
using proDuck.Application.Features.Queries.Order.OrderDetail.GetByIdOrderDetail;

namespace proDuck.WebApi.Controllers
{
    [Route("api/orderDetails")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdOrderDetailQueryRequest getByIdOrderDetailQueryRequest)
        {
            GetByIdOrderDetailQueryResponse response = await _mediator.Send(getByIdOrderDetailQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllOrderDetailQueryRequest getAllOrderDetailQueryRequest)
        {
            GetAllOrderDetailQueryResponse response = await _mediator.Send(getAllOrderDetailQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderDetailCommandRequest createOrderDetailCommandRequest)
        {
            CreateOrderDetailCommandResponse response = await _mediator.Send(createOrderDetailCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOrderDetailCommandRequest request)
        {
            UpdateOrderDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderDetailCommandRequest request)
        {
            DeleteOrderDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
