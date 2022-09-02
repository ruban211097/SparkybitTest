using Infrastructure.CommandQueries.Commands;
using MassTransit;
using MediatR;
using Messsaging.Messages;

namespace Messsaging.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        private IMediator _mediator;
        public UserCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            Console.WriteLine("User created " + context.Message.Name);
            await _mediator.Send(new CreateUserCommand() { Name = context.Message.Name });
        }
    }
}
