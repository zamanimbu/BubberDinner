using BubberDinner.Application.Common.Interfaces;
using BubberDinner.Application.Common.Services;
using BubberDinner.Infrastructure.Authentication;
using BubberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BubberDinner.Application.Common.Persistence;
using BubberDinner.Infrastructure.Persistence;

namespace BubberDinner.Infrastructure.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUesrRepository, UserRepository>();

            return services;
        }
    }
}
