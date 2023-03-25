namespace Dinner.Application.Common.Interfaces.Persistance
{
    using Dinner.Domain.Entities;

    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUser(string email);
    }
}