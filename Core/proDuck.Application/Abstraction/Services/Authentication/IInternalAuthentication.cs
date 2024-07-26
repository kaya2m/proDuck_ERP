using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> LoginAsync(string userNameOremail, string password);

    }
}
