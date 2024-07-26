using proDuck.Application.Features.Commands.AppUser.CreateUser;
using proDuck.Application.Features.Commands.AppUser.FacebookLogin;
using proDuck.Application.Features.Commands.AppUser.GoogleLogin;
using proDuck.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proDuck.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
    }
}
