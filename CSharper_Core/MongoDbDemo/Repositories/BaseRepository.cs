using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDbDemo.Models;

namespace MongoDbDemo.Repositories
{
    public class BaseRepository<TCollection> where TCollection : BaseDocument
    {
        private readonly IMongoClient m_client;
        private readonly IMongoDatabase m_db;
        protected readonly IMongoCollection<TCollection> Collection;

        public BaseRepository(string collectionName, string dbName = Constants.DbName, string connectionString = Constants.ConnectionString)
        {

            m_client = new MongoClient(connectionString);
            m_db = m_client.GetDatabase(dbName);
            Collection = m_db.GetCollection<TCollection>(collectionName);
        }


        public async Task<List<BsonDocument>> GetDbListAsync()
        {
            return await m_client.ListDatabases().ToListAsync();
        }

        public IMongoDatabase GetCurrentDb()
        {
            return m_db;
        }
        public IMongoCollection<TCollection> GetCollection()
        {
            return Collection;
        }

        public async Task InsertOneAsync(TCollection document)
        {
            await Collection.InsertOneAsync(document);
        }

        public async Task<List<TCollection>> GetAllAsync()
        {
            return await Collection.Find(d => true).ToListAsync();
        }

        public virtual async Task<TCollection> GetOneAsync(string id)
        {
            return await Collection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }
    }
}