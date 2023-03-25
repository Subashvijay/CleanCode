
namespace Dinner.Application
{
    using Dinner.Application.Services.Auth;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddTransient<IAuthService, AuthService>();
            return service;
        }
    }
}