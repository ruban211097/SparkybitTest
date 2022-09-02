using Infrastructure;
using MassTransit;
using MediatR;
using Messsaging.Consumers;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumerApp
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Logger.Init();
            var serviceProvider = ConsoleDI.Init(args);

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("user-created-event", e =>
                {
                    e.Consumer(() => new UserCreatedConsumer(serviceProvider.GetService<IMediator>()));
                });
            });

            await busControl.StartAsync(new CancellationToken());

            try
            {
                Console.WriteLine("Press enter to exit");
                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}