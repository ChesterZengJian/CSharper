using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbDemo.Models;

namespace MongoDbDemo.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        private readonly IMongoCollection<Author> m_authorCollection;

        public BookRepository(string collectionName, string dbName = Constants.DbName, string connectionString = Constants.ConnectionString) : base(collectionName, dbName, connectionString)
        {
            var authorRepository = new BaseRepository<Author>(Constants.AuthorCollection);
            m_authorCollection = authorRepository.GetCollection();
        }

        public async Task<List<LookedUpAuthors>> GetBookAsync(string id)
        {
            var query = from book in Collection.AsQueryable()
                        join author in m_authorCollection on book.AuthorId equals author.Id into joinedAuthors
                        select new LookedUpAuthors()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            InnerAuthors = joinedAuthors
                        };

            return await query.ToListAsync();
        }
    }

    public class LookedUpAuthors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }
        // Add more properties as you need

        public IEnumerable<Author> InnerAuthors { get; set; }
    }
}