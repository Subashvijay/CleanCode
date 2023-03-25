using Dinner.Contracts.Authentication;

namespace Dinner.Application.Services.Auth
{
    public interface IAuthService
    {
        LoginRequest Login(LoginRequest request);

        RegisterRequest Register(RegisterRequest request);
    }
}