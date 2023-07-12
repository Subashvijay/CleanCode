
namespace Dinner.Application
{
    using Dinner.Application.Services.Auth.Queries;
    using Dinner.Application.Services.Auth.Commands;

    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddTransient<IAuthCommandService, AuthCommandService>();
            service.AddTransient<IAuthQueryService, AuthQueryService>();
            service.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return service;
        }
    }
}