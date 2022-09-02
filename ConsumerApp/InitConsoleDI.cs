using Infrastructure;
using Messsaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumerApp
{
    internal static class ConsoleDI
    {
        public static ServiceProvider Init(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddCommandLine(args)
              .Build();

            var serviceProvider = new ServiceCollection()
                .AddMessagingLayer()
                .AddInfrastructureLayer(configuration)
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
