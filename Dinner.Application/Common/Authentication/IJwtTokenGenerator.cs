using Dinner.Contracts.Authentication;

namespace Dinner.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string FirstName, string LastName);
    }
}