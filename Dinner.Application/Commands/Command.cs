
namespace Dinner.Application.Commands;

using Dinner.Application.Common.Errors;
using Dinner.Application.Services.Auth.Models;

using FluentResults;

using MediatR;

using OneOf;

public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Token) : IRequest<OneOf<AuthResult, DuplicateEmailError>>;

public record LoginCommand(
string Email,
string Password
) : IRequest<Result<AuthResult>>;
