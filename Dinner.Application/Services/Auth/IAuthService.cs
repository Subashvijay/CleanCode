using Dinner.Contracts.Authentication;

namespace Dinner.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Login(LoginRequest request);

        AuthResult Register(RegisterRequest request);
    }
}