using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<TokenDto> LoginAsync(string userNameOremail, string password);

    }
}
