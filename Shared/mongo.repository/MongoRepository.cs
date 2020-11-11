using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace mongo.repository
{
    public class MongoRepository : IRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoClient client, string database)
        {
            _database = client.GetDatabase(database);
        }

        public async Task Add<T>(T entity, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);

            await collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<TDocument>> Query<TDocument>(string collectionName, Expression<Func<TDocument, bool>> query)
        {
            var collection = _database.GetCollection<TDocument>(collectionName);

            var result = await collection.FindAsync(
                new FilterDefinitionBuilder<TDocument>().Where(query));

            return result.ToEnumerable();
        }
    }
}