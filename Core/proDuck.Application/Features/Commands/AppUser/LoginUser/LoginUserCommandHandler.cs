using MediatR;
using proDuck.Application.DTOs;
using proDuck.Application.Abstraction.Services;

namespace proDuck.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
         
           TokenDto token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password);
            return new LoginUserSuccessResponse()
            {
                Token = token
            };
        }
    }
}
