using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginUserCommandRequest : IRequest<FacebookLoginUserCommandResponse>
    {
        public string Id { get; set; }
        public string AuthToken { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }
    }
}
