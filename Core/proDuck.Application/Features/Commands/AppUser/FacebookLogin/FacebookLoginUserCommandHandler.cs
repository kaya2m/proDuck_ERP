using proDuck.Application.Abstraction.Services;
using proDuck.Application.Abstraction.Token;
using proDuck.Application.DTOs;
using proDuck.Application.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using User = proDuck.Domain.Entities.Identity;
namespace proDuck.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginUserCommandHandler : IRequestHandler<FacebookLoginUserCommandRequest, FacebookLoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public FacebookLoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginUserCommandResponse> Handle(FacebookLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            proDuck.Application.DTOs.Facebook.FacebookLogin query = new DTOs.Facebook.FacebookLogin()
            {
                Id = request.Id,
                AuthToken = request.AuthToken,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Name = request.Name,
                PhotoUrl = request.PhotoUrl,
                Provider = request.Provider
            };
             FacebookLoginResponse token = await _authService.FacebookLoginAsync(query);
                return new()
                {
                    Token = token.Token
                };
        }
    }
}
