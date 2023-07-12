namespace Dinner.Application.Services.Auth.Commands;

using Dinner.Application.Commands;
using Dinner.Application.Common.Errors;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistance;
using Dinner.Application.Services.Auth.Models;
using Dinner.Domain.Entities;

using OneOf;

public class AuthCommandService : IAuthCommandService
{
    private readonly IJwtTokenGenerator _JWTTokenGenerator;
    private readonly IUserRepository _UserRepository;

    public AuthCommandService(IJwtTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
    {
        this._UserRepository = userRepository;
        _JWTTokenGenerator = jWTTokenGenerator;
    }

    public OneOf<AuthResult, DuplicateEmailError> Register(RegisterCommand request)
    {
        if (_UserRepository.GetUser(request.Email) is not null)
        {
            return new DuplicateEmailError();
        }
        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
        _UserRepository.AddUser(user);
        var token = _JWTTokenGenerator.GenerateToken(user);
        return new AuthResult(
            user.Id,
             request.FirstName,
             request.LastName,
             request.Email,
             token
        );
    }
}
