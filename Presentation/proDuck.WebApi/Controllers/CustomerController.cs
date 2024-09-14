using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using proDuck.Application.Features.Commands.Customer.CreateCustomer;
using proDuck.Application.Features.Commands.Customer.DeleteCustomer;
using proDuck.Application.Features.Commands.Customer.UpdateCustomer;
using proDuck.Application.Features.Queries.Customer.GetAllCustomer;
using proDuck.Application.Features.Queries.Customer.GetByIdCustomer;

namespace proDuck.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            GetByIdCustomerQueryResponse response = await _mediator.Send(getByIdCustomerQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            GetAllCustomerQueryResponse response = await _mediator.Send(getAllCustomerQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCustomerCommandRequest request)
        {
            UpdateCustomerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommandRequest request)
        {
           DeleteCustomerCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
    }
}
