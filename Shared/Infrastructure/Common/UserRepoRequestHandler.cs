using MediatR;

namespace Infrastructure.Common
{
    public abstract class UserRepoRequestHandler<TRequest, TResponse> :
        IRequestHandler<TRequest, TResponse> where TRequest :
        IRequest<TResponse>
    {
        protected readonly IUsersRepo _usersRepo;
        public UserRepoRequestHandler(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo ?? throw new ArgumentNullException(nameof(usersRepo));
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
