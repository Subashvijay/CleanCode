using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Application.Common.Interfaces.Persistance;
using Dinner.Domain.Entities;

namespace Dinner.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User? GetUser(string Email)
        {
            return users.Find(user => user.Email == Email);
        }
    }
}