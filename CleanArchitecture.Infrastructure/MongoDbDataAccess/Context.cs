using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.MongoDbDataAccess
{
    public class Context
    {
        private readonly IMongoDatabase _Db;

        public Context(IMongoClient client, string dbName)
        {
            _Db = client.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) => _Db.GetCollection<T>(name);
    }
}
