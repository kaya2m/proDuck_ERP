using proDuck.Application.DTOs.Facebook;
using proDuck.Application.DTOs.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Abstraction.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<FacebookLoginResponse> FacebookLoginAsync(FacebookLogin model);
        Task<GoogleLoginResponse> GoogleLoginAsync(GoogleLogin model);
    }
}
