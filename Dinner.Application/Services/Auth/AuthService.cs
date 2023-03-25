using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistance;
using Dinner.Contracts.Authentication;
using Dinner.Domain.Entities;

namespace Dinner.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _JWTTokenGenerator;
        private readonly IUserRepository _UserRepository;

        public AuthService(IJwtTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
        {
            this._UserRepository = userRepository;
            _JWTTokenGenerator = jWTTokenGenerator;
        }

        public AuthResult Login(LoginRequest request)
        {
            if (_UserRepository.GetUser(request.Email) is not User user)
            {
                throw new Exception("User Not Found.");
            }

            if (user.Password != request.Password)
            {
                throw new Exception("Invalid Password.");
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

        public AuthResult Register(RegisterRequest request)
        {
            if (_UserRepository.GetUser(request.Email) is not null)
            {
                throw new Exception("User Already exist");
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
}