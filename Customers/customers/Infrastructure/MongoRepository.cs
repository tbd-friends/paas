using System.Threading.Tasks;
using MongoDB.Driver;

namespace customers.Infrastructure
{
    public class MongoRepository : IRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoClient client)
        {
            _database = client.GetDatabase("customers-service");
        }

        public async Task Add<T>(T entity, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);

            await collection.InsertOneAsync(entity);
        }
    }
}