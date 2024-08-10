using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
       
    }

    public class LoginUserSuccessResponse : LoginUserCommandResponse
    {

        public TokenDto Token { get; set; }
    }

    public class LoginUserFailResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
