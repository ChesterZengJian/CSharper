using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Models
{
    public class Author : BaseDocument
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string ScientificDegree { get; set; }
    }
}