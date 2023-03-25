namespace Dinner.Application.Services.Auth
{
    using Dinner.Application.Common.Errors;
    using Dinner.Contracts.Authentication;

    using OneOf;

    public interface IAuthService
    {
        AuthResult Login(LoginRequest request);

        OneOf<AuthResult, DuplicateEmailError> Register(RegisterRequest request);
    }
}