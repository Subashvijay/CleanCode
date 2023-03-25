namespace Dinner.Infrastructure.Persistance
{
    using Dinner.Application.Common.Interfaces.Persistance;
    using Dinner.Domain.Entities;

    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new();
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User? GetUser(string email)
        {
            return users.Find(user => user.Email == email);
        }
    }
}