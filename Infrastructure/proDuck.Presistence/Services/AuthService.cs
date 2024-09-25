using proDuck.Application.Abstraction.Services;
using proDuck.Application.Abstraction.Token;
using proDuck.Application.DTOs;
using proDuck.Application.Exceptions;
using proDuck.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

        private async Task<TokenDto> CreateUserExternalAsync(AppUser user, string email, string firstName, UserLoginInfo info)
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

                TokenDto token = _tokenHandler.CreateAccessToken(5000);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }
        public async Task<TokenDto> LoginAsync(string userNameOrEmail, string password)
        {
            AppUser user = await _userManager.FindByNameAsync(userNameOrEmail)
                           ?? await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                throw new NotFoundUserException("Invalid login credentials");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                throw new AuthenticationErrorExcepiton("Invalid login credentials"); 
            }

            TokenDto token = _tokenHandler.CreateAccessToken(15000);

            return token;
        }

    }
}
