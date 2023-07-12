namespace Dinner.Application.Services.Auth.Queries
{
    using Dinner.Application.Commands;
    using Dinner.Application.Services.Auth.Models;

    using FluentResults;

    public interface IAuthQueryService
    {
        Result<AuthResult> Login(LoginCommand request);
    }
}