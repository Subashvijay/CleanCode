namespace Dinner.Application.Services.Auth.Commands
{
    using Dinner.Application.Common.Errors;
    using Dinner.Application.Services.Auth.Models;
    using Dinner.Application.Commands;

    using OneOf;

    public interface IAuthCommandService
    {
        OneOf<AuthResult, DuplicateEmailError> Register(RegisterCommand request);
    }
}