using Infrastructure.Common;
using Infrastructure.Models;
using MediatR;

namespace Infrastructure.CommandQueries.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        public class GetAllUsersQueryHandler : UserRepoRequestHandler<GetAllUsersQuery, List<User>>
        {
            public GetAllUsersQueryHandler(IUsersRepo usersRepo) : base(usersRepo)
            {
            }
            public override async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _usersRepo.GetAsync();
            }
        }
    }
}
