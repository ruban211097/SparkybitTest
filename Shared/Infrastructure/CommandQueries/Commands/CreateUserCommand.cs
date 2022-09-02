using Infrastructure.CommandQueries.Models;
using Infrastructure.Common;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.CommandQueries.Commands
{
    public class CreateUserCommand : IRequest<Result>
    {
        [Required]
        public string Name { get; set; }
        public class CreateUserCommandHandler : UserRepoRequestHandler<CreateUserCommand, Result>
        {
            public CreateUserCommandHandler(IUsersRepo usersRepo) : base(usersRepo)
            {
            }

            public override async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    await _usersRepo.CreateAsync(command.Name);
                }
                catch (Exception ex)
                {
                    List<string> errors = new List<string>() { ex.Message };
                    return Result.Failure(errors);
                }
                return Result.Success();
            }
        }
    }
}
