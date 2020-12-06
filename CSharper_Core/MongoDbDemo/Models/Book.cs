using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Models
{
    public class Book : BaseDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }

        public string Title { get; set; }

        public int PublishYear { get; set; }

        public string Content { get; set; }

        public bool IsVerified { get; set; }

        public int DownloadCount { get; set; }
    }
}