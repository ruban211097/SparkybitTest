using Infrastructure.Common;
using Infrastructure.Repos;
using Infrastructure.ServiceComponents;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection("Database"));
            services.AddSingleton<IUsersRepo, UsersRepo>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
