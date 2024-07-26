using System.Threading;
using System.Threading.Tasks;
using proDuck.Application.Abstraction.Services;
using proDuck.Application.DTOs.User;
using proDuck.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace proDuck.Application.Features.Commands.AppUser.CreateUser
{
     public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUser _user;

        public CreateUserCommandHandler(IUser user)
        {
            _user = user;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
         CreateUserResponse response =   await _user.CreateAsync(new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                UserName = request.UserName,
                PasswordConfirm = request.PasswordConfirm
            });

            return new CreateUserCommandResponse
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
            //throw new UserCreateFailedException();
        }
    }
}
