using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Auth
{
    public record AuthResult(Guid Id, string FirstName, string LastName, string Email, string Token);
}