namespace Dinner.Application.Common.Interfaces.Authentication
{
    using Dinner.Domain.Entities;

    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}