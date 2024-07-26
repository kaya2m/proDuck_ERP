using proDuck.Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace proDuck.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int second)
        {
            // Initialize a new Token object
            Application.DTOs.Token token = new();

            // Create a SymmetricSecurityKey using the configured security key
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // Create signing credentials using the security key and algorithm
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Set the expiration time for the token (1 day in this case)
            token.Expiration = DateTime.UtcNow.AddSeconds(second);

            // Create a JwtSecurityToken with necessary parameters
            JwtSecurityToken securityToken = new(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            // Create a JwtSecurityTokenHandler and write the token
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
