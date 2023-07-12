namespace Dinner.Application.Services.Auth.Queries;

using Dinner.Application.Commands;
using Dinner.Application.Common.Errors;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistance;
using Dinner.Application.Services.Auth.Models;
using Dinner.Domain.Entities;

using FluentResults;

public class AuthQueryService : IAuthQueryService
{
    private readonly IJwtTokenGenerator _JWTTokenGenerator;
    private readonly IUserRepository _UserRepository;

    public AuthQueryService(IJwtTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
    {
        this._UserRepository = userRepository;
        _JWTTokenGenerator = jWTTokenGenerator;
    }

    public Result<AuthResult> Login(LoginCommand request)
    {
        if (_UserRepository.GetUser(request.Email) is not User user)
        {
            throw new Exception("User Not Found.");
        }

        if (user.Password != request.Password)
        {
            return Result.Fail(new LoginError("Invalid Password."));
        }
        var token = _JWTTokenGenerator.GenerateToken(user);
        return new AuthResult(
            user.Id,
             user.FirstName,
             user.LastName,
             request.Email,
             token
        );
    }
}
