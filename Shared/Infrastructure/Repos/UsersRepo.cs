using Infrastructure.Common;
using Infrastructure.Models;
using Infrastructure.ServiceComponents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repos
{
    internal class UsersRepo : IUsersRepo
    {
        private readonly IMongoCollection<User> _userCollection;

        public UsersRepo(IOptions<DatabaseSettings> userStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                userStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userStoreDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(
                userStoreDatabaseSettings.Value.CollectionName);
        }
        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();
        public async Task CreateAsync(string name)
        {
            User newUser = new User()
            {
                UserId = Guid.NewGuid().ToString(),
                Name = name,
                CreatedDate = DateTime.Now
            };
            await _userCollection.InsertOneAsync(newUser);
        }
    }
}
