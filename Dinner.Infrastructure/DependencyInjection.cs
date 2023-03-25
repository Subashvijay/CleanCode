using Dinner.Application.Common.Authentication;
using Dinner.Application.Common.Services;
using Dinner.Infrastructure.Auth;
using Dinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Dinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraService(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}