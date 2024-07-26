using proDuck.Application.Abstraction.Services;
using proDuck.Application.Abstraction.Token;
using proDuck.Application.DTOs;
using proDuck.Application.DTOs.Facebook;
using proDuck.Application.DTOs.Google;
using proDuck.Application.Exceptions;
using proDuck.Application.Features.Commands.AppUser.LoginUser;
using proDuck.Domain.Entities;
using proDuck.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proDuck.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly HttpClient _httpClient;
        readonly IConfiguration configuration;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        public AuthService(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager)
        {
            _httpClient = httpClientFactory.CreateClient();
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            this.configuration = configuration;
            _signInManager = signInManager;
        }

        private async Task<Token> CreateUserExternalAsync(AppUser user, string email, string firstName, UserLoginInfo info)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        FirstName = firstName
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

                Token token = _tokenHandler.CreateAccessToken(5000);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }
        public async Task<FacebookLoginResponse> FacebookLoginAsync(FacebookLogin model)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={configuration["ExternalLoginSettings:Facebook:Client_Id"]}&client_secret={configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");
            FacebookAccessTokenResponse facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AuthToken}&access_token={facebookAccessTokenResponse.AccessToken}");

            FacebookUserAccessTokenValidation validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);

            if (validation is not null && validation.Data.IsValid)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={model.AuthToken}");

                FacebookUserInfoResponse userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                Token token = await CreateUserExternalAsync(user, userInfo.Email, userInfo.Name, info);
                return new()
                {
                    Token = token
                };
            }
            throw new Exception("Invalid external authentication.");
        }
        public async Task<GoogleLoginResponse> GoogleLoginAsync(GoogleLogin model)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { configuration["ExternalLoginSettings:Google:ClientId"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(model.IdToken, settings);
            var info = new UserLoginInfo(model.Provider, payload.Subject, model.Provider);
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            Token token = await CreateUserExternalAsync(user, payload.Email, payload.Name, info);
            return new()
            {
                Token = token
            };
        }
        public async Task<Token> LoginAsync(string userNameOremail, string password)
        {
            AppUser user = await _userManager.FindByNameAsync(userNameOremail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOremail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(15000);
                return token;
            }
            throw new AuthenticationErrorExcepiton("Kullanıcı bulunamadı");
        }
    }
}
