using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Messsaging
{
    public static class MessagingServiceExtension
    {
        public static IServiceCollection AddMessagingLayer(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
