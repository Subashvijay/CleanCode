using Dinner.Domain.Entities;

namespace Dinner.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUser(string Email);
    }
}