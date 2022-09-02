using Infrastructure.Models;

namespace Infrastructure.Common
{
    public interface IUsersRepo
    {
        Task CreateAsync(string name);
        Task<List<User>> GetAsync();
    }
}