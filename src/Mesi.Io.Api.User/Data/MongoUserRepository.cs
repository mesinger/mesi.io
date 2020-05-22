using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Mesi.Io.Api.User.Data
{
    public class MongoUserRepository : IUserRepository
    {
        private readonly IMongoCollection<MongoUserEntity> _collection;
        
        public MongoUserRepository(IUserMongoDbSettings dbSettings, ILogger<MongoUserRepository> logger)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _collection = database.GetCollection<MongoUserEntity>(dbSettings.CollectionName);
            
            logger.LogInformation($"Mongo settings = {dbSettings.ConnectionString}/{dbSettings.DatabaseName}/{dbSettings.CollectionName}");
        }

        public void Save(Models.User user)
        {
            _collection.InsertOneAsync(user.ToMongo());
        }

        public async Task<Models.User?> GetById(string userId)
        {
            var user = await _collection.FindAsync(u => u.UserId == userId).Result.FirstOrDefaultAsync();
            return user?.ToDomain();
        }

        public async Task<Models.User?> GetByName(string username)
        {
            var user = await _collection.FindAsync(u => u.UserName == username).Result.FirstOrDefaultAsync();
            return user?.ToDomain();
        }

        public async Task<Models.User?> GetByEmail(string email)
        {
            var user = await _collection.FindAsync(u => u.Email == email).Result.FirstOrDefaultAsync();
            return user?.ToDomain();
        }
    }
}