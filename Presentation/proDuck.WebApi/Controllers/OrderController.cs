using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using proDuck.Application.Features.Commands.Order.CreateOrder;
using proDuck.Application.Features.Commands.Order.DeleteOrder;
using proDuck.Application.Features.Commands.Order.UpdateOrder;
using proDuck.Application.Features.Queries.Order.GetAllOrder;
using proDuck.Application.Features.Queries.Order.GetByIdOrder;
using static Google.Apis.Requests.BatchRequest;

namespace proDuck.WebApi.Controllers;

[Route("api/orders")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdOrderQueryRequest getByIdOrderQueryRequest)
    {
        GetByIdOrderQueryResponse response = await _mediator.Send(getByIdOrderQueryRequest);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllOrderQueryRequest getAllOrderQueryRequest)
    {
        GetAllOrderQueryResponse response = await _mediator.Send(getAllOrderQueryRequest);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderCommandRequest createOrderCommandRequest)
    {
        CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateOrderCommandRequest request)
    {
       UpdateOrderCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteOrderCommandRequest request)
    {
        DeleteOrderCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
