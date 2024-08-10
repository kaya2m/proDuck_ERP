using proDuck.Application.DTOs;

namespace proDuck.Application.Abstraction.Token;

public interface ITokenHandler  
{
    TokenDto CreateAccessToken(int second);
}
