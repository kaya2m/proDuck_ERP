using entity = proDuck.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.Exceptions;
using proDuck.Application.Abstraction.Token;
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
         
           Token token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password);
            return new LoginUserSuccessResponse()
            {
                Token = token
            };
        }
    }
}
