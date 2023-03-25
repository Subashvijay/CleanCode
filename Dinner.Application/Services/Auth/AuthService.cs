using Dinner.Application.Common.Authentication;
using Dinner.Contracts.Authentication;

namespace Dinner.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _JWTTokenGenerator;

        public AuthService(IJwtTokenGenerator jWTTokenGenerator)
        {
            _JWTTokenGenerator = jWTTokenGenerator;
        }

        public LoginRequest Login(LoginRequest request)
        {
            return request;
        }

        public RegisterRequest Register(RegisterRequest request)
        {
            var token = _JWTTokenGenerator.GenerateToken(Guid.NewGuid(), request.FirstName, request.LastName);
            var result = new RegisterRequest(
                 request.FirstName,
                 request.LastName,
                 request.Email,
                 request.Password,
                 token
            );
            return result;
        }
    }
}